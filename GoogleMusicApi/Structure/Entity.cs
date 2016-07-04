using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class Entity
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("explicitType")]
        public int ExplicitType { get; set; }

    }
}