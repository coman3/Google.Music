using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class StationAnnotationSeedMetadata
    {
        [JsonProperty("station")]
        public Station Station { get; set; }
    }
}