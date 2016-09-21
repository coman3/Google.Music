using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class GetStationFeed : StructuredRequest<GetStationFeedRequest, RadioFeed>
    {
        public override string RelativeRequestUrl => "radio/stationfeed";
    }
}
