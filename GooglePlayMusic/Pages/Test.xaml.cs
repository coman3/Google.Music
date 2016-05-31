using GoogleMusicApi.Requests;
using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;
using GooglePlayMusic.Desktop.Managers;
using System;
using System.Linq;
using System.Windows.Controls;

namespace GooglePlayMusic.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Page
    {
        public Test()
        {
            InitializeComponent();
            LoadTracks();
        }

        public StationSeed GetFirstValidStationSeed(StationSeed seed)
        {
            if (!string.IsNullOrWhiteSpace(seed.CuratedStationId))
                return seed;
            if (seed.Seeds == null) return null;

            foreach (var stationSeed in seed.Seeds)
            {
                var value = GetFirstValidStationSeed(stationSeed);
                if (value != null) return value;
            }
            return null;
        }

        private async void LoadTracks()
        {
            PlaybackManager.OnPlaybackStateChange += PlaybackManager_OnPlaybackStateChange;
            var request = await new ListListenNowSituations().GetAsync(new ListListenNowSituationsRequest(SessionManager.MobileClient.Session));
            StationSeed seed = null;
            foreach (var source in request.Situations.Where(x => x.Stations != null))
            {
                if (source.Stations == null) continue;

                foreach (var station in source.Stations)
                {
                    seed = GetFirstValidStationSeed(station.Seed);
                    if (seed != null) break;
                }
            }
            if (seed == null) return;

            var annotaion = await new GetRadioStationAnnotation().GetAsync(new GetRadioStationAnnotationRequest(SessionManager.MobileClient.Session, seed));

            var tracks =
                await new EditRadioStation().GetAsync(new EditRadioStationRequest(SessionManager.MobileClient.Session,
                    new EditRadioStationRequestMutation
                    {
                        CreateOrGet = new EditRadioStationRequestCreateOrGetMutation
                        {
                            ClientId = SessionManager.MobileClient.Session.UserDetails.AndroidId,
                            ImageType = 1,
                            InLibary = false,
                            LastModifiedTimestamp = "-1",
                            Name = "Test Data",
                            RecentTimestamp = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString("#"),
                            Seed = seed,
                            Deleted = false,
                        },
                        IncludeFeed = true,
                        NumberOfEntries = 50,
                        Parameters = new EditRadioStationRequestParameters
                        {
                            ContentFilter = 1
                        }
                    }));

            foreach (var mutation in tracks.MutateReponse)
            {
                if (mutation.Tracks != null)
                    foreach (var track in mutation.Tracks)
                    {
                        TrackManager.Queue.Enqueue(track);
                    }
                else if (mutation.Station?.Tracks != null)
                    foreach (var track in mutation.Station.Tracks)
                    {
                        TrackManager.Queue.Enqueue(track);
                    }
            }
            dataGrid.IsReadOnly = true;
            dataGrid.AutoGenerateColumns = true;
            dataGrid.ItemsSource = TrackManager.Queue;
        }

        private void PlaybackManager_OnPlaybackStateChange(NAudio.Wave.BufferedWaveProvider sender, PlaybackManager.StreamingPlaybackState state)
        {
            Dispatcher.Invoke(() =>
            {
                dataGrid.Items.Refresh();
            });
        }
    }
}