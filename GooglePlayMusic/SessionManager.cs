using System.Collections;
using System.Collections.Generic;
using System.Windows;
using GoogleMusicApi;
using GoogleMusicApi.Structure;

namespace GooglePlayMusic
{
    public static class SessionManager
    {
        public static Window CurrentWindow { get; set; }
        public static MobileSession MobileSession { get; set; }
        public static Queue<Track> Queue { get; set; } = new Queue<Track>();

        public static ListListenNowSituationResponse ListenNowSituationResponse { get; set; }
        public static ListListenNowTracksResponse ListenNowTracksResponse { get; set; }

    }
}