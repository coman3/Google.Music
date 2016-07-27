using GoogleMusicApi.UWP.Requests.Data;

namespace GoogleMusicApi.UWP.Requests
{
    public class ExploreTabs : StructuredRequest<ExploreTabsRequest, ExploreTabsResponse>
    {
        public override string RelativeRequestUrl => "explore/tabs";
    }

    //TODO (Low): Split Into Separate Files
}