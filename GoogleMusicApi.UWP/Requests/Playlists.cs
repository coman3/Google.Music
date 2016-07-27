using GoogleMusicApi.UWP.Requests.Data;
using GoogleMusicApi.UWP.Structure;

namespace GoogleMusicApi.UWP.Requests
{
    public class Playlists : StructuredRequest<PlaylistsRequest, Playlist>
    {
        public override string RelativeRequestUrl => "playlists";
    }
}