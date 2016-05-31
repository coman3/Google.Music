using GoogleMusicApi.Common;
using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Sessions;

namespace GooglePlayMusic.Desktop.Managers
{
    public static class SessionManager
    {
        public static ListListenNowSituationResponse ListenNowSituationResponse { get; set; }
        public static ListListenNowTracksResponse ListenNowTracksResponse { get; set; }
        public static MobileClient MobileClient { get; set; }
    }
}