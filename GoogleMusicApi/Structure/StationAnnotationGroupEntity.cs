using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class StationAnnotationGroupEntity
    {
        [JsonProperty("station")]
        public Station Station { get; set; }
        [JsonProperty("artist")]
        public Artist Artist { get; set; }
        [JsonProperty("genre")]
        public Genre Genre { get; set; } //TODO: Maybe?
    }
}