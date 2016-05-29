using System;
using System.Collections.Generic;
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
using GooglePlayMusic.Common;
using GooglePlayMusic.Managers;

namespace GooglePlayMusic.Pages
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        public Index()
        {
            InitializeComponent();
            LoadingOverlay.Visibility = Visibility.Visible;
        }

        private async void Index_OnLoaded(object sender, RoutedEventArgs e)
        {
            await LoadListenNowSituations();
            await LoadListenNowData();

            var streamRequest = new ListPromotedTracks().Get(new ResultListRequest(SessionManager.MobileSession));
            foreach (var track in streamRequest.Data.Items)
            {
                var url = new GetStreamUrl().Get(new StreamUrlGetRequest(SessionManager.MobileSession, track));
                TrackManager.CurrentTrack = track;
                PlaybackManager.PlayTrack(url);
                break;
            }

            LoadingOverlay.Visibility = Visibility.Visible;
            LoadingOverlay.SetSolid();

            LoadingOverlay.Visibility = Visibility.Hidden;
        }

        private async Task LoadListenNowSituations()
        {
            var data = await
                new ListListenNowSituations().GetAsync(new ListListenNowSituationsRequest(SessionManager.MobileSession));
            if (data == null) return;
            SessionManager.ListenNowSituationResponse = data;
            SituationTitle.Text = data.PrimaryHeader;
            SituationDescription.Text = data.SubHeader;
            foreach (var situation in data.Situations)
            {
                var card = new Card(new BitmapImage(new Uri(situation.ImageUrl)),
                    situation.Title, situation.Description)
                {
                    Width = 250,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    MinWidth = 225
                };
                ListenNowSituationPanel.Children.Add(card);
            }

        }

        private async Task LoadListenNowData()
        {
            var data = await new ListListenNowTracks().GetAsync(new GetRequest(SessionManager.MobileSession));
            SessionManager.ListenNowTracksResponse = data;
            if (data == null) return;
            foreach (var item in data.Items)
            {
                if (item.CompositeArtRefs != null && item.CompositeArtRefs.Length > 0)
                {
                    var card =
                        new Card(
                            new BitmapImage(new Uri(item.CompositeArtRefs.First(x => x.AspectRatio == "1").Url)),
                            item.Album != null ? item.Album.Title : item.RadioStation.Title, item.SuggestionText)
                        {
                            Width = (BaseStackPanel.ActualWidth - (7*4*2) - 20)/4,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            MinWidth = 125
                        };
                    ListenNowWrapPanel.Children.Add(card);
                }
            }
        }

        private void Page_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResizeListenNowSuggestionCards();
        }

        private void ResizeListenNowSuggestionCards()
        {

            foreach (Control child in ListenNowWrapPanel.Children)
            {
                if (ActualWidth < 800)
                {
                    child.Width = (BaseStackPanel.ActualWidth - (7 * 4 * 2) - 20) / 2;
                }
                else
                {
                    child.Width = (BaseStackPanel.ActualWidth - (7*4*2) - 20)/4;
                }
            }
        }
    }
}
