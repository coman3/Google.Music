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
            UrlData.Add(new WebRequestHeader("alt", "json"));
            UrlData.Add(new WebRequestHeader("hl", "en_AU"));
        }

        public override byte[] GetRequestBody()
        {
            var json = JsonConvert.SerializeObject(this);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}