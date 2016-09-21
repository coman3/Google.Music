using GoogleMusicApi.UWP.Requests.Data;
using GoogleMusicApi.UWP.Structure;

namespace GoogleMusicApi.UWP.Requests
{
    public class PlentryFeed : StructuredRequest<FeedRequest, ResultList<PlaylistEntry>>
    {
        public override string RelativeRequestUrl => "plentryfeed";
    }
}
