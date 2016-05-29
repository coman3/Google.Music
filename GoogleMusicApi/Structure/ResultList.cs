using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class ResultList<T>
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonProperty("data")]
        public DataSet<T> Data { get; set; }
    }

    public class DataSet<T>
    {
        [JsonProperty("items")]
        public List<T> Items { get; set; }
    }
}