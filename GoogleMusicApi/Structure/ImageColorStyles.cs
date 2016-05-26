using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class ImageColorStyles
    {
        [JsonProperty("primary")]
        public ImageColorStyle Primary { get; set; }
        [JsonProperty("scrim")]
        public ImageColorStyle Scrim { get; set; }
        [JsonProperty("accent")]
        public ImageColorStyle Accent { get; set; }
    }

    [JsonObject]
    public class ImageColorStyle
    {
        [JsonProperty("red")]
        public int Red { get; set; }
        [JsonProperty("green")]
        public int Green { get; set; }
        [JsonProperty("blue")]
        public int Blue { get; set; }

    }
}