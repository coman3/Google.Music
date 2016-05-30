using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    //TODO (Low): Context-Token when played top charts, figure out where that came from
    public class GetTrackFeed : StructuredRequest<ResultListRequest, ResultList<Track>>
    {
        public override string RelativeRequestUrl => "trackfeed";
    }
}