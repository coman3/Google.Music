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
            
        }


        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var listenNowData = await new ListListenNowTracks().GetAsync(new GetRequest(SessionManager.MobileSession));
            foreach (var data in listenNowData.Items)
            {
                if (data.CompositeArtRefs != null && data.CompositeArtRefs.Length > 0)
                {
                    var item = new Image
                    {
                        Source = new BitmapImage(new Uri(data.CompositeArtRefs.FirstOrDefault(x=> x.AspectRatio == "1").Url)),
                        Height = (BaseStackPanel.ActualHeight - 80) / 4,
                        Width = (BaseStackPanel.ActualWidth - 80) / 4,
                        Stretch = Stretch.UniformToFill,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                        
                        
                    };
                    BaseStackPanel.Children.Add(item);
                }
            }


            LoadingOverlay.Visibility = Visibility.Hidden;
        }
    }
}
