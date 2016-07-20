using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure
{
    public class StationAnnotation
    {
        [JsonProperty("albumQuilt")]
        public AlbumQuilt AlbumbQuilt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("headerArtRefs")]
        public ArtReference[] HeaderImages { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("profileName")]
        public string ProfileName { get; set; }

        [JsonProperty("profileOwnerImages")]
        public ArtReference[] ProfileOwnerImages { get; set; }

        [JsonProperty("seedMetadata")]
        public StationAnnotationSeedMetadata SeedMetadata { get; set; }

        [JsonProperty("stationImageRefs")]
        public ArtReference[] StationImageReferences { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}