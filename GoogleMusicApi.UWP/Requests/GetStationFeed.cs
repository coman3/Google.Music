using GoogleMusicApi.UWP.Requests.Data;
using GoogleMusicApi.UWP.Structure;

namespace GoogleMusicApi.UWP.Requests
{
    public class GetStationFeed : StructuredRequest<GetStationFeedRequest, RadioFeed>
    {
        public override string RelativeRequestUrl => "radio/stationfeed";
    }
}
