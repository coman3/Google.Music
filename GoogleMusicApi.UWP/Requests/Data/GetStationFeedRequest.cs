using GoogleMusicApi.UWP.Sessions;
using GoogleMusicApi.UWP.Structure;
using GoogleMusicApi.UWP.Structure.Enums;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GetStationFeedRequest : PostRequest
    {
        [JsonProperty("contentFilter")]
        public ExplicitType ContentFilter { get; set; }

        [JsonProperty("stations")]
        public StationFeedStation[] Stations { get; set; }


        public GetStationFeedRequest(Session session, StationFeedStation[] stations) : base(session)
        {
            Stations = stations;
        }
    }
}