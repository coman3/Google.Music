using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using GoogleMusicApi.Requests;
using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;
using GooglePlayMusic.Desktop.Utilities;
using NAudio.Wave;
using Timer = System.Timers.Timer;

namespace GooglePlayMusic.Desktop.Managers
{
    public static class PlaybackManager
    {
        public static volatile StreamingPlaybackState PlaybackState;
        public static TimeSpan TrackTimeSpan { get; set; }
        public static void ChangePlaybackState(StreamingPlaybackState state)
        {
            PlaybackState = state;
            OnPlaybackStateChange?.Invoke(_bufferedWaveProvider, _currentTrack, state);
        }

        public static VolumeWaveProvider16 VolumeProvider { get; set; }
        public static IWavePlayer WaveOut { get; set; }

        public enum StreamingPlaybackState
        {
            Stopped,
            Playing,
            Buffering,
            Paused
        }
        public static volatile bool FullyDownloaded;
        public static event OnBufferStateChangeHandler OnBufferStateChange;
        public static event OnPlaybackStateChangeHandler OnPlaybackStateChange;


        private static HttpWebRequest _webRequest;
        private static BufferedWaveProvider _bufferedWaveProvider;
        private static readonly Timer Timer;
        private static Track _currentTrack;
        static PlaybackManager()
        {
            Timer = new Timer(100);
            Timer.Elapsed += _timer_Elapsed;
        }

        private static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (PlaybackState != StreamingPlaybackState.Stopped)
            {
                if (WaveOut == null && _bufferedWaveProvider != null)
                {
                    Debug.WriteLine("Creating WaveOut Device");
                    WaveOut = new WaveOut();
                    WaveOut.PlaybackStopped += OnPlaybackStopped;
                    var currentVolume = 1f;
                    if (VolumeProvider != null)
                    {
                        currentVolume = VolumeProvider.Volume;
                    }
                    VolumeProvider = new VolumeWaveProvider16(_bufferedWaveProvider)
                    {
                        Volume = currentVolume
                    };
                    WaveOut.Init(VolumeProvider);
                }
                else if (_bufferedWaveProvider != null)
                {
                    var bufferedSeconds = _bufferedWaveProvider.BufferedDuration.TotalSeconds;
                    ShowBufferState(bufferedSeconds);
                    if (PlaybackState == StreamingPlaybackState.Playing)
                        TrackTimeSpan += TimeSpan.FromMilliseconds(Timer.Interval);

                    // make it stutter less if we buffer up a decent amount before playing
                    if (bufferedSeconds < 0.5 && PlaybackState == StreamingPlaybackState.Playing && !FullyDownloaded)
                    {
                        Pause();
                    }
                    else if (bufferedSeconds > 10 && PlaybackState == StreamingPlaybackState.Buffering)
                    {
                        Play();
                    }
                    else if (FullyDownloaded && Math.Abs(bufferedSeconds) < float.Epsilon)
                    {
                        Debug.WriteLine("Reached end of stream");
                        StopPlayback();
                    }

                }

            }
        }

        private static void StopPlayback()
        {
            if (PlaybackState != StreamingPlaybackState.Stopped)
            {
                TrackTimeSpan = TimeSpan.Zero;
                if (!FullyDownloaded)
                {
                    _webRequest.Abort();
                }

                ChangePlaybackState(StreamingPlaybackState.Stopped);
                if (WaveOut != null)
                {
                    WaveOut.Stop();
                    WaveOut.Dispose();
                    WaveOut = null;
                }
                Timer.Stop();
                _bufferedWaveProvider = null;
                // n.b. streaming thread may not yet have exited
                Thread.Sleep(600);
                ShowBufferState(0);
            }
        }

        private static void Play()
        {
            if (WaveOut != null)
            {
                WaveOut.Play();
                Debug.WriteLine("Started playing, waveOut.PlaybackState={0}", WaveOut.PlaybackState);
                ChangePlaybackState(StreamingPlaybackState.Playing);
            }
        }

        private static void Pause()
        {
            ChangePlaybackState(StreamingPlaybackState.Buffering);
            WaveOut?.Pause();
            Debug.WriteLine("Paused to buffer, waveOut.PlaybackState={0}", WaveOut?.PlaybackState);
        }

        private static void ShowBufferState(double bufferedSeconds)
        {
            OnBufferStateChange?.Invoke(_bufferedWaveProvider, _currentTrack, bufferedSeconds);
        }

        private static void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            
        }

        public static async void PlayTrack(Track track)
        {
            var streamUrl = await SessionManager.MobileClient.GetStreamUrlAsync(track);
            if(streamUrl == null) return;
            _currentTrack = track;
            PlayTrack(streamUrl);
        }

        public static void PlayTrack(Uri streamUrl)
        {
            if (PlaybackState == StreamingPlaybackState.Stopped)
            {
                ChangePlaybackState(StreamingPlaybackState.Buffering);
                _bufferedWaveProvider = null;
                ThreadPool.QueueUserWorkItem(StreamMp3, streamUrl);
                TrackTimeSpan = new TimeSpan();
                Timer.Start();
            }
            else if (PlaybackState == StreamingPlaybackState.Paused)
            {
                ChangePlaybackState(StreamingPlaybackState.Buffering);
            }
        }

        public static void SetState(PlaybackState state)
        {

            if (state == NAudio.Wave.PlaybackState.Playing && PlaybackState == StreamingPlaybackState.Paused)
            {
                WaveOut?.Play();
                ChangePlaybackState(StreamingPlaybackState.Buffering);
            }
            else if (state == NAudio.Wave.PlaybackState.Paused && (PlaybackState == StreamingPlaybackState.Playing))
            {
                WaveOut?.Pause();
                ChangePlaybackState(StreamingPlaybackState.Paused);
            }
            else if(state == NAudio.Wave.PlaybackState.Stopped)
            {
                StopPlayback();
            }
        }

        private static bool IsBufferNearlyFull => _bufferedWaveProvider != null && _bufferedWaveProvider.BufferLength - _bufferedWaveProvider.BufferedBytes < _bufferedWaveProvider.WaveFormat.AverageBytesPerSecond/4;

        private static void StreamMp3(object state)
        {
            FullyDownloaded = false;
            var url = (Uri) state;
            _webRequest = (HttpWebRequest) WebRequest.Create(url);
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse) _webRequest.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status != WebExceptionStatus.RequestCanceled)
                {
                    MessageBox.Show(e.Message);
                }
                return;
            }
            var buffer = new byte[16384*4]; // needs to be big enough to hold a decompressed frame

            IMp3FrameDecompressor decompressor = null;
            try
            {
                using (var responseStream = resp.GetResponseStream())
                {
                    var readFullyStream = new ReadFullyStream(responseStream);
                    do
                    {
                        if (IsBufferNearlyFull)
                        {
                            //Debug.WriteLine("Buffer getting full, taking a break");
                            Thread.Sleep(500);
                            continue;
                        }
                        Mp3Frame frame;
                        try
                        {
                            frame = Mp3Frame.LoadFromStream(readFullyStream);
                        }
                        catch (EndOfStreamException)
                        {
                            FullyDownloaded = true;
                            // reached the end of the MP3 file / stream
                            break;
                        }
                        catch (WebException)
                        {
                            // probably we have aborted download from the GUI thread
                            break;
                        }
                        if (decompressor == null)
                        {
                            // don't think these details matter too much - just help ACM select the right codec
                            // however, the buffered provider doesn't know what sample rate it is working at
                            // until we have a frame
                            decompressor = CreateFrameDecompressor(frame);
                            _bufferedWaveProvider = new BufferedWaveProvider(decompressor.OutputFormat)
                            {
                                BufferDuration = TimeSpan.FromSeconds(60)
                            };
                            // allow us to get well ahead of ourselves
                            //this._bufferedWaveProvider.BufferedDuration = 250;
                        }
                        if (frame == null)
                        {
                            FullyDownloaded = true;
                            break;
                        }

                        int decompressed = decompressor.DecompressFrame(frame, buffer, 0);
                        //Debug.WriteLine(String.Format("Decompressed a frame {0}", decompressed));
                        _bufferedWaveProvider.AddSamples(buffer, 0, decompressed);
                    } while (PlaybackState != StreamingPlaybackState.Stopped);
                    // was doing this in a finally block, but for some reason
                    // we are hanging on response stream .Dispose so never get there
                    decompressor?.Dispose();
                }
            }
            finally
            {
                decompressor?.Dispose();
            }
        }

        private static IMp3FrameDecompressor CreateFrameDecompressor(Mp3Frame frame)
        {
            WaveFormat waveFormat = new Mp3WaveFormat(frame.SampleRate, frame.ChannelMode == ChannelMode.Mono ? 1 : 2, frame.FrameLength, frame.BitRate);
            return new AcmMp3FrameDecompressor(waveFormat);
        }
    }

    public delegate void OnPlaybackStateChangeHandler(BufferedWaveProvider sender, Track track, PlaybackManager.StreamingPlaybackState state);

    public delegate void OnBufferStateChangeHandler(BufferedWaveProvider sender, Track track, double totalSecconds);
}