using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class ListListenNowTracksResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("listennow_items")]
        public ListenNowItem[] Items { get; set; }
    }
}