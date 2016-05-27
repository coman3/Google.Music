using GoogleMusicApi;
using GoogleMusicApi.Structure;

namespace GooglePlayMusic.Managers
{
    public static class SessionManager
    {
        public static ListListenNowSituationResponse ListenNowSituationResponse { get; set; }
        public static ListListenNowTracksResponse ListenNowTracksResponse { get; set; }
        public static MobileSession MobileSession { get; set; }
    }
}