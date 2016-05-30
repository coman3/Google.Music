using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ListListenNowSituations :
        StructuredRequest<ListListenNowSituationsRequest, ListListenNowSituationResponse>
    {
        public override string RelativeRequestUrl => "listennow/situations";
    }
}