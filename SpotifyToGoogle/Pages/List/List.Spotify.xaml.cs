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
using SpotifyAPI.Web.Models;

namespace SpotifyToGoogle.Pages.List
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class SpotifyList : Page
    {
        public List<SimplePlaylist> Playlists { get; set; }
        public Paragraph Paragraph { get; set; }
        public SpotifyList()
        {
            InitializeComponent();
            Paragraph = new Paragraph();
            ProccessLog.Document = new FlowDocument(Paragraph);
            if (SessionManager.SpotifyClient != null) LoadPlaylists();
        }

        private async void LoadPlaylists()
        {
            var playlists = SessionManager.SpotifyClient.GetUserPlaylists(SessionManager.SpotifyProfile.Id);
            if (playlists == null)
            {
                MessageBox.Show("Error Collecting Spotify Playlists.");
                return;
            }
            Playlists = playlists.Items ?? new List<SimplePlaylist>();
            DataGrid.ItemsSource = Playlists;
            DataGrid.Items.Refresh();
        }

        private async void CopyToGoogleButtonClick(object sender, RoutedEventArgs e)
        {
            ProccessLog.Visibility = Visibility.Visible;
            var items = DataGrid.SelectedItems.OfType<SimplePlaylist>();
            foreach (var playlist in items)
            {
                Paragraph.Inlines.Add(new AccessText
                {
                    Text = $"Loading playlist  '{playlist.Name}' from Spotify...\n",
                    Foreground = Brushes.DeepPink,
                });
                
                var tracks = await SessionManager.SpotifyClient.GetPlaylistTracksAsync(playlist.Owner.Id, playlist.Id);
                var newTracks = new List<Track>();
                Paragraph.Inlines.Add(new AccessText
                {
                    Text = $"Loaded!\n",
                    Foreground = Brushes.Green,
                });
                Paragraph.Inlines.Add(new AccessText
                {
                    Text = $"Searching Google and adding tracks from playlist...\n",
                    Foreground = Brushes.DeepPink,
                });
                foreach (var track in tracks.Items)
                {
                    var result = await SessionManager.GoogleClient.SearchAsync(track.Track.Name);
                    var songs = result.Entries.Where(x => x.Track != null);
                    var data = new Dictionary<SearchResult, SongMatchScore>();

                    foreach (var song in songs)
                    {
                        data.Add(song, new SongMatchScore
                        {
                            AlbumName = LevenshteinDistance.Compute(song.Track.Album, track.Track.Album.Name),
                            ArtistsName =
                                LevenshteinDistance.Compute(song.Track.Artist, track.Track.Artists.First().Name),
                            GoogleSearchScore = -song.NavigationalConfidence,
                            SongName = LevenshteinDistance.Compute(track.Track.Name, song.Track.Title),
                            Bonus = CalculateBonuses(track, song.Track)
                        });
                    }
                    data = data.OrderBy(x => x.Value.Total).ToDictionary(x => x.Key, y => y.Value);
                    var addTrack = data.First().Key.Track;
                    newTracks.Add(addTrack);
                    ProccessLog.AppendText($"Added Track: {addTrack.Title} (By: {addTrack.Artist}) from Spotify Track: {track.Track.Name} (By: {string.Join(",", track.Track.Artists.Select(x => x.Name))})\n");
                }
                var newPlaylist = await SessionManager.GoogleClient.CreatePlaylist(playlist.Name, "");
                await SessionManager.GoogleClient.AddSongToPlaylist(newPlaylist, newTracks.ToArray());
                
            }
            Paragraph.Inlines.Add(new AccessText
            {
                Text = "Created Playlist!",
                Foreground = Brushes.Green,
            });
        }

        private float CalculateBonuses(PlaylistTrack currentTrack, Track newTrack)
        {
            var bonus = 0f;

            var namesJoint = string.Join(" ", newTrack.Title, newTrack.Album,
                newTrack.Artist, newTrack.AlbumArtist).ToLower();
            if (namesJoint.Contains(currentTrack.Track.Name.ToLower())) bonus += 1;
            if (namesJoint.Contains(currentTrack.Track.Album.Name.ToLower())) bonus += 5;

            foreach (var x in currentTrack.Track.Artists)
            {
                if (namesJoint.Contains(x.Name.ToLower()))
                {
                    bonus += 5;
                }
                if (newTrack.Artist.ToLower().Contains(x.Name.ToLower()))
                {
                    bonus += 20;
                }
            }
            return -bonus;

        }
    }

    internal class SongMatchScore
    {
        public int SongName { get; set; }
        public int ArtistsName { get; set; }
        public int AlbumName { get; set; }
        public float GoogleSearchScore { get; set; }

        public float Total => Bonus + SongName + ArtistsName + AlbumName + GoogleSearchScore;
        public float Bonus { get; set; }
    }

    static class LevenshteinDistance
    {
        public static int Compute(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                return t.Length;
            }

            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }
    }

}
