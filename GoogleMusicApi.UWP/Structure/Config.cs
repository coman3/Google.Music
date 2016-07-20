using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure
{
    [JsonObject]
    public class Config
    {
        [JsonProperty("data")]
        public ConfigEntries Data { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }
    }

    [JsonObject]
    public class ConfigData
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    [JsonObject]
    public class ConfigEntries
    {
        [JsonProperty("entries")]
        public ConfigData[] Entries { get; set; }
    }
}