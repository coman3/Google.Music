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
using GoogleMusicApi.Structure;

namespace SpotifyToGoogle.Pages.List
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class GoogleList : Page
    {
        public List<Playlist> Playlists { get; set; }
        public GoogleList()
        {
            InitializeComponent();
            if (SessionManager.GoogleClient != null) LoadPlaylists();
        }

        private async void LoadPlaylists()
        {
            var playlists = await SessionManager.GoogleClient.ListPlaylistsAsync(1000);
            if (playlists == null )
            {
                MessageBox.Show("Error Collecting Google Playlists.");
                return;
            }
            Playlists = playlists.Data == null ? new List<Playlist>() : playlists.Data.Items;
            DataGrid.ItemsSource = Playlists;
            DataGrid.Items.Refresh();
        }
    }
}
