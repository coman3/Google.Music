using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ListPlaylists : StructuredRequest<ResultListRequest, ResultList<Playlist>>
    {
        public override string RelativeRequestUrl => "playlistfeed";
    }
}