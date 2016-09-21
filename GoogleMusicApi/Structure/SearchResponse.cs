using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class SearchResponse
    {
        [JsonProperty("clusterOrder")]
        public string[] ClusterOrder { get; set; }

        [JsonProperty("entries")]
        public SearchResult[] Entries { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("suggestedQuery")]
        public string SuggestedQuery { get; set; }
    }
}