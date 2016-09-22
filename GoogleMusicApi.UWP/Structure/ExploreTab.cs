using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class ExploreTab
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("tab_type")]
        public string TabType { get; set; }

        [JsonProperty("groups")]
        public EntityGroup[] EntityGroups { get; set; }

        [JsonProperty("data_status")]
        public string DataStatus { get; set; }



    }
}