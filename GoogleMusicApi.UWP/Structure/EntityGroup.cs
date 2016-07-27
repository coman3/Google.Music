using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure
{
    public class EntityGroup
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("entities")]
        public Entity[] Entities { get; set; }

        [JsonProperty("group_type")]
        public string GroupType { get; set; }

        [JsonProperty("continuation_token")]
        public string ContinuationToken { get; set; }

        [JsonProperty("start_position")]
        public int StartPosistion { get; set; }

    }
}