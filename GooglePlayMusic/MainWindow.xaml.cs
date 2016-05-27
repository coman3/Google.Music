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

namespace GooglePlayMusic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if(SessionManager.MobileSession.IsAuthenticated)
                InitializeComponent();
            else throw new InvalidOperationException("Session Not Authenticated");
            LoadingOverlay.Visibility = Visibility.Visible;
            LoadingOverlay.SetSolid();
            

        }


        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            await LoadListenNowSituations();
            LoadingOverlay.SetNonSoild();
            await LoadListenNowData();
            
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
                    Width = (BaseStackPanel.ActualWidth - (7 * 4 * 2 + 80)) /6,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    MinWidth = 125
                };
                ListenNowSituationPanel.Children.Add(card);
            }

        }

        private async Task LoadListenNowData()
        {
            var listenNowData = await new ListListenNowTracks().GetAsync(new GetRequest(SessionManager.MobileSession));
            if (listenNowData == null) return;
            foreach (var data in listenNowData.Items)
            {
                if (data.CompositeArtRefs != null && data.CompositeArtRefs.Length > 0)
                {
                    var item = new Card(new BitmapImage(new Uri(data.CompositeArtRefs.FirstOrDefault(x => x.AspectRatio == "1").Url)), data.Album != null ? data.Album.Title : data.RadioStation.Title, data.SuggestionText)
                    {
                        Width = (BaseStackPanel.ActualWidth - (7 * 4 * 2)) / 4,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        MinWidth = 125


                    };
                    ListenNowWrapPanel.Children.Add(item);
                }
            }
        }

        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResizeListenNowSuggestionCards();
            ResizeListenNowSituationCards();
        }

        private void ResizeListenNowSuggestionCards()
        {

            foreach (Control child in ListenNowWrapPanel.Children)
            {
                child.Width = (BaseStackPanel.ActualWidth - (7 * 4 * 2)) / 4;
            }
        }
        private void ResizeListenNowSituationCards()
        {

            foreach (Control child in ListenNowSituationPanel.Children)
            {
                child.Width = (BaseStackPanel.ActualWidth - (7 * 4 * 2 + 20)) / 6;
            }
        }
    }
}
