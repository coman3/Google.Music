using System.Text;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RecordRealTimeRequest : PostRequest
    {
        [JsonProperty("currentTimeMillis")]
        public string CurrentTimeMillis { get; set; }

        [JsonProperty("events")]
        public Event[] Events { get; set; }


        public RecordRealTimeRequest(Session session) : base(session)
        {
        }

    }
}