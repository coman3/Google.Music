using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Artist
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("artistArtRef")]
        public string ArtistArtRef { get; set; }

        [JsonProperty("artistArtRefs")]
        public ArtReference[] ArtistArtRefs { get; set; }

        [JsonProperty("artistBio")]
        public string ArtistBio { get; set; }

        [JsonProperty("artistId")]
        public string ArtistId { get; set; }

        [JsonProperty("albums")]
        public Album[] Albums { get; set; }

        [JsonProperty("topTracks")]
        public Track[] TopTracks { get; set; }

        [JsonProperty("total_albums")]
        public int TotalAlbums { get; set; }

        [JsonProperty("artist_bio_attribution")]
        public Attribution ArtistBioAttribution { get; set; }
    }
}