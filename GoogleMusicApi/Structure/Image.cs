using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Image
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("url", Required = Required.Always)]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }
}