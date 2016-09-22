using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class PlaylistFeed : StructuredRequest<FeedRequest, ResultList<Playlist>>
    {
        public override string RelativeRequestUrl => "playlistfeed";
    }
}