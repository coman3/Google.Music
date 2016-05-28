using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ListTrackFeed : StructuredRequest<ResultListRequest, ResultList<Track>>
    {
        public override string RelativeRequestUrl => "trackfeed";
    }
}