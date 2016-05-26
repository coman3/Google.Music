using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class ListenNowStation
    {
        [JsonProperty("highlight_color")]
        public string HighlightColor { get; set; }

        [JsonProperty("id")]
        public StationSeed Id { get; set; }

        [JsonProperty("profile_image")]
        public ArtReference ProfileImage { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

    }
}