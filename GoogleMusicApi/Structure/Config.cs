using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Config
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("data")]
        public ConfigEntries Data { get; set; }
    }
    [JsonObject]
    public class ConfigEntries
    {
        [JsonProperty("entries")]
        public ConfigData[] Entries { get; set; }
    }

    [JsonObject]
    public class ConfigData
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}