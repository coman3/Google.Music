using GoogleMusicApi.UWP.Requests.Data;

namespace GoogleMusicApi.UWP.Requests
{
    public class ListListenNowSituations :
        StructuredRequest<ListListenNowSituationsRequest, ListListenNowSituationResponse>
    {
        public override string RelativeRequestUrl => "listennow/situations";
    }
}