using GoogleMusicApi.Sessions;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class GetStationFeedRequest : PostRequest
    {
        [JsonProperty("contentFilter")]
        public int ContentFilter { get; set; }

        [JsonProperty("stations")]
        public StationFeedStation[] Stations { get; set; }


        public GetStationFeedRequest(Session session, StationFeedStation[] stations) : base(session)
        {
            Stations = stations;
        }
    }
}