using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GoogleMusicApi;
using GoogleMusicApi.Requests;
using GoogleMusicApi.Structure;
using GooglePlayMusic.Managers;

namespace GooglePlayMusic.Pages
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Page
    {
        public Test()
        {
            InitializeComponent();
            PlaybackManager.OnPlaybackStateChange += PlaybackManager_OnPlaybackStateChange;
            var request = new ListListenNowSituations().Get(new ListListenNowSituationsRequest(SessionManager.MobileSession));
            StationSeed seed = null;
            foreach (var source in request.Situations.Where(x=> x.Stations != null))
            {
                if(source.Stations == null) continue;
                
                foreach (var station in source.Stations)
                {
                    seed = GetFirstValidStationSeed(station.Seed);
                    if(seed != null) break;
                }
            }
            if (seed == null) return;
            
            var annotaion = new RadioStationAnnotation().Get(new GetRadioStationAnnotationRequest(SessionManager.MobileSession, seed));

            var tracks =
                new EditRadioStation().Get(new EditRadioStationRequest(SessionManager.MobileSession,
                    new EditRadioStationRequestMutation
                    {
                        CreateOrGet = new EditRadioStationRequestCreateOrGetMutation
                        {
                            ClientId = SessionManager.MobileSession.AndroidId,
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
    }
}
