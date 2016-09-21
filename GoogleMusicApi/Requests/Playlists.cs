using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class Playlists : StructuredRequest<PlaylistsRequest, Playlist>
    {
        public override string RelativeRequestUrl => "playlists";
    }
}