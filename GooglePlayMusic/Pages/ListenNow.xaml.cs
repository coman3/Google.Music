using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using GoogleMusicApi;
using GoogleMusicApi.Requests;
using GoogleMusicApi.Requests.Data;
using GooglePlayMusic.Desktop.Common;
using GooglePlayMusic.Desktop.Managers;

namespace GooglePlayMusic.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for ListenNow.xaml
    /// </summary>
    public partial class ListenNow : Page
    {
        public bool LoadedData { get; set; }
        public ListenNow()
        {
            InitializeComponent();
            LoadingOverlay.Visibility = Visibility.Visible;
            Loaded += ListenNow_Loaded;
        }

        private async void ListenNow_Loaded(object sender, RoutedEventArgs e)
        {
            if(LoadedData) return;
            
            var data = await SessionManager.MobileClient.ListListenNowSituationsAsync();
            SituationTitle.Text = data.PrimaryHeader;
            SituationDescription.Text = data.SubHeader;
            SituationCardList.LoadData(data);
            LoadedData = true;

            LoadingOverlay.Visibility = Visibility.Hidden;
        }
    }
}
