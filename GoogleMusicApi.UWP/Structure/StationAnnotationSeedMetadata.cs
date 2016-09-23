using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure
{
    public class StationAnnotationSeedMetadata
    {
        [JsonProperty("station")]
        public Station Station { get; set; }
    }
}