using GoogleMusicApi.Requests;
using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class StationAnnotation
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("stationImageRefs")]
        public ArtReference[] StationImageReferences { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("profileName")]
        public string ProfileName { get; set; }
        [JsonProperty("profileOwnerImages")]
        public ArtReference[] ProfileOwnerImages { get; set; }
        [JsonProperty("headerArtRefs")]
        public ArtReference[] HeaderImages { get; set; }
        [JsonProperty("seedMetadata")]
        public StationAnnotationSeedMetadata SeedMetadata { get; set; }
        [JsonProperty("albumQuilt")]
        public AlbumQuilt AlbumbQuilt { get; set; }
    }
}