using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class ImageColorStyle
    {
        [JsonProperty("blue")]
        public int Blue { get; set; }

        [JsonProperty("green")]
        public int Green { get; set; }

        [JsonProperty("red")]
        public int Red { get; set; }
    }

    [JsonObject]
    public class ImageColorStyles
    {
        [JsonProperty("accent")]
        public ImageColorStyle Accent { get; set; }

        [JsonProperty("primary")]
        public ImageColorStyle Primary { get; set; }

        [JsonProperty("scrim")]
        public ImageColorStyle Scrim { get; set; }
    }
}