using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class StationAnnotationRelatedGroup
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("groupType")]
        public string GroupType { get; set; }

        [JsonProperty("groupEntities")]
        public StationAnnotationGroupEntity[] GroupEntities { get; set; }
    }
}