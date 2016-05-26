using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class ArtReference
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("aspectRatio")]
        public string AspectRatio { get; set; }

        [JsonProperty("autogen")]
        public bool Autogen { get; set; }

        [JsonProperty("colorStyles")]
        public ImageColorStyles ColorStyles { get; set; }
    }
}