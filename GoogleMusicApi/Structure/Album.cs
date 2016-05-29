using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Album
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("albumArtist")]
        public string AlbumArtist { get; set; }

        [JsonProperty("albumArtRef")]
        public string AlbumArtRef { get; set; }

        [JsonProperty("albumId")]
        public string AlbumId { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("artistId")]
        public string[] ArtistId { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description_attribution")]
        public Attribution DescriptionAttribution { get; set; }

        [JsonProperty("explicitType")]
        public string ExplicitType { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }
    }
}