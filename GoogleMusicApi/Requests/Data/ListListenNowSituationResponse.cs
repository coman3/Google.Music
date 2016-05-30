using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    [JsonObject]
    public class ListListenNowSituationResponse
    {
        [JsonProperty("distilledContextWrapper")]
        public DistilledContextWrapper DistilledContextWrapper { get; set; }

        [JsonProperty("primaryHeader")]
        public string PrimaryHeader { get; set; }

        [JsonProperty("subHeader")]
        public string SubHeader { get; set; }

        [JsonProperty("situations")]
        public Situation[] Situations { get; set; }
    }

    [JsonObject]
    public class DistilledContextWrapper
    {
        [JsonProperty("distilledContextToken")]
        public string DistilledContextToken { get; set; }
    }
}