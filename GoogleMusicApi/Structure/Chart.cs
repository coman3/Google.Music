using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class Chart
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }
    }
}