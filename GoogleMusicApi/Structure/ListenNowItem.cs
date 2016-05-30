using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class ListenNowItem
    {
        [JsonProperty("album")]
        public ListenNowAlbum Album { get; set; }

        [JsonProperty("compositeArtRefs")]
        public ArtReference[] CompositeArtRefs { get; set; }

        [JsonProperty("images")]
        public ArtReference[] Images { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("radio_station")]
        public ListenNowStation RadioStation { get; set; }

        [JsonProperty("suggestion_reason")]
        public string SuggestionReason { get; set; }

        [JsonProperty("suggestion_text")]
        public string SuggestionText { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}