using GoogleMusicApi.Sessions;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ResultListRequest : PostRequest
    {
        [JsonProperty("max-results")]
        public int MaxResults { get; set; }

        [JsonProperty("start-token")]
        public string StartToken { get; set; }

        public ResultListRequest(Session session) : base(session)
        {
            MaxResults = 1000;
        }
    }
}