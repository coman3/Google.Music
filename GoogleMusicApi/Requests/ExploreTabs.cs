using GoogleMusicApi.Requests.Data;

namespace GoogleMusicApi.Requests
{
    public class ExploreTabs : StructuredRequest<ExploreTabsRequest, ExploreTabsResponse>
    {
        public override string RelativeRequestUrl => "explore/tabs";
    }

    //TODO (Low): Split Into Separate Files
}