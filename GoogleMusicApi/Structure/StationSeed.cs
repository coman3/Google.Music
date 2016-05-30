using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class StationMetaDataSeed
    {
        [JsonProperty("artist")]
        public Artist Artist { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }
    }

    [JsonObject]
    public class StationSeed
    {
        [JsonProperty("albumId")]
        public string AlbumId { get; set; }

        [JsonProperty("artistId")]
        public string ArtistId { get; set; }

        [JsonProperty("curatedStationId")]
        public string CuratedStationId { get; set; }

        [JsonProperty("genreId")]
        public string GenreId { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("metadataSeed")]
        public StationMetaDataSeed MetadataSeed { get; set; }

        [JsonProperty("seeds")]
        public StationSeed[] Seeds { get; set; }

        [JsonProperty("seedType")]
        public string SeedType { get; set; }

        [JsonProperty("trackId")]
        public string TrackId { get; set; }

        [JsonProperty("trackLockerId")]
        public string TrackLockerId { get; set; }
    }
}