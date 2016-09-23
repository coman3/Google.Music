using GoogleMusicApi.UWP.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    public class ListListenNowTracksResponse
    {
        [JsonProperty("listennow_items")]
        public ListenNowItem[] Items { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }
    }
}