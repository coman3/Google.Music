using GoogleMusicApi.UWP.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    public class ExploreTabsResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("tabs")]
        public ExploreTab[] Tabs { get; set; }
    }
}