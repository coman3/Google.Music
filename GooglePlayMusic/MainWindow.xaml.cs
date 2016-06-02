using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GoogleMusicApi;
using GoogleMusicApi.Requests;
using GooglePlayMusic.Desktop.Common;
using GooglePlayMusic.Desktop.Managers;
using NAudio.Wave;
using Track = GoogleMusicApi.Structure.Track;

namespace GooglePlayMusic.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double PopupQueueHeight => ActualHeight - 300;
        public double PopupQueueWidth => Math.Min(ActualWidth - 450, 500);

        public MainWindow()
        {
            WindowManager.NavigateToAction = page =>
            {
                ContentProvider.Source = page;
            };
            InitializeComponent();
            PlaybackManager.OnBufferStateChange += PlaybackManager_OnBufferStateChange;
            PlaybackManager.OnPlaybackStateChange += PlaybackManager_OnPlaybackStateChange;
            TrackManager.OnQueueChange += TrackManager_OnQueueChange;
        }

        private void TrackManager_OnQueueChange(object sender, QueueChangeEventArgs args)
        {
            if (!Dispatcher.CheckAccess()) Dispatcher.Invoke(() => { TrackManager_OnQueueChange(sender, args); });

            UpdateCurrentSongInfo(TrackManager.CurrentTrack);
        }

        private void UpdateCurrentSongInfo(Track currentTrack)
        {
            
        }

        private void PlaybackManager_OnPlaybackStateChange(BufferedWaveProvider sender, Track track,
            PlaybackManager.StreamingPlaybackState state)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(() => { PlaybackManager_OnPlaybackStateChange(sender, track, state); });
                return;
            }
            switch (state)
            {
                case PlaybackManager.StreamingPlaybackState.Playing:
                    PlayPauseMusic.IsChecked = true;
                    break;
                case PlaybackManager.StreamingPlaybackState.Paused:
                    PlayPauseMusic.IsChecked = false;
                    break;
            }

        }

        private void PlaybackManager_OnBufferStateChange(BufferedWaveProvider sender, Track track,
            double totalSecconds)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(() => { PlaybackManager_OnBufferStateChange(sender, track, totalSecconds); });
                return;
            }

            TrackProgressBar.Maximum = TrackManager.CurrentTrack.DurationMillis;
            TrackProgressBar.Value = PlaybackManager.TrackTimeSpan.TotalSeconds * 1000;

            TrackBufferProgressBar.Maximum = TrackManager.CurrentTrack.DurationMillis;
            TrackBufferProgressBar.Value = (PlaybackManager.TrackTimeSpan.TotalSeconds + totalSecconds) * 1000;

            Debug.WriteLine(PlaybackManager.TrackTimeSpan);

        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var tb = sender as ToggleButton;
            if (tb?.IsChecked == null) return;
            if (PlaybackManager.PlaybackState == PlaybackManager.StreamingPlaybackState.Stopped)
                PlaybackManager.PlayTrack(TrackManager.CurrentTrack = TrackManager.Queue.Dequeue());
            else if(PlaybackManager.PlaybackState != PlaybackManager.StreamingPlaybackState.Buffering)
                PlaybackManager.SetState(tb.IsChecked.Value ? PlaybackState.Playing : PlaybackState.Paused);
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (PlaybackManager.PlaybackState != PlaybackManager.StreamingPlaybackState.Buffering)
            {
                PlaybackManager.SetState(PlaybackState.Stopped);
                PlaybackManager.PlayTrack(TrackManager.GetNextSong());
            }
                

        }
    }
}
