using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Attribution
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("license_url")]
        public string LicenseUrl { get; set; }

        [JsonProperty("license_title")]
        public string LicenseTitle { get; set; }

        [JsonProperty("source_title")]
        public string SourceTitle { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }
    }
}