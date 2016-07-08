using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    //TODO (Low): Context-Token when played top charts, figure out where that came from
    public class ListTrackFeed : StructuredRequest<ResultListRequest, ResultList<Track>>
    {
        public override string RelativeRequestUrl => "trackfeed";
    }
}