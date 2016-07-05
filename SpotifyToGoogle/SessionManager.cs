using System;
using GoogleMusicApi.Common;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;

namespace SpotifyToGoogle
{
    public static class SessionManager
    {
        public static MobileClient GoogleClient { get; set; }
        public static SpotifyWebAPI SpotifyClient { get; set; }
        public static PrivateProfile SpotifyProfile { get; set; }

        public static void CheckNextStep()
        {
            if (GoogleClient != null && SpotifyClient != null)
            {
                MainWindow.NavigateNew(MainWindow.ApiType.Google, new Uri("Pages/List/List.Google.xaml", UriKind.Relative));
                MainWindow.NavigateNew(MainWindow.ApiType.Spotify, new Uri("Pages/List/List.Spotify.xaml", UriKind.Relative));
            }
        }
    }
}