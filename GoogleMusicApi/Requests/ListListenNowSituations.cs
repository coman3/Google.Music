using GoogleMusicApi.Requests.Data;

namespace GoogleMusicApi.Requests
{
    public class ListListenNowSituations :
        StructuredRequest<ListListenNowSituationsRequest, ListListenNowSituationResponse>
    {
        public override string RelativeRequestUrl => "listennow/situations";
    }
}