using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class ListListenNowTracksResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("listennow_items")]
        public ListenNowItem[] Items { get; set; }
    }
}