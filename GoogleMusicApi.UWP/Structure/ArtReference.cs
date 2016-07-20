using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure
{
    [JsonObject]
    public class ArtReference
    {
        [JsonProperty("aspectRatio")]
        public string AspectRatio { get; set; }

        [JsonProperty("autogen")]
        public bool Autogen { get; set; }

        [JsonProperty("colorStyles")]
        public ImageColorStyles ColorStyles { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}