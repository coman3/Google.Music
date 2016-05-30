using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoogleMusicApi.Structure
{
    public class DataSet<T>
    {
        [JsonProperty("items")]
        public List<T> Items { get; set; }
    }

    [JsonObject]
    public class ResultList<T>
    {
        [JsonProperty("data")]
        public DataSet<T> Data { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("nextPageToken")]
        public string NextPageToken { get; set; }
    }
}