using System.Text;
using Newtonsoft.Json;

namespace GoogleMusicApi
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ResultListRequest : PostRequest
    {
        [JsonProperty("start-token")]
        public string StartToken { get; set; }

        [JsonProperty("max-results")]
        public int MaxResults { get; set; }
        public override byte[] GetRequestBody()
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this));
        }

        public ResultListRequest(Session session) : base(session)
        {
            MaxResults = 1000;
        }
    }
}