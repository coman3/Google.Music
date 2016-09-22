using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class PlentryFeed : StructuredRequest<FeedRequest, ResultList<Plentry>>
    {
        public override string RelativeRequestUrl => "plentryfeed";
    }
}
