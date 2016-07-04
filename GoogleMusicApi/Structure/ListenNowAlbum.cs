using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class ListenNowAlbum
    {
        [JsonProperty("artist_metajam_id")]
        public string ArtistMetajamId { get; set; }

        [JsonProperty("artist_name")]
        public string ArtistName { get; set; }

        [JsonProperty("artist_profile_image")]
        public ArtReference ArtistProfileImage { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description_attribution")]
        public Attribution DescriptionAttribution { get; set; }

        [JsonProperty("id")]
        public ListenNowAlbumId Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("explicitType")]
        public Enums.ExplicitType ExplicitType { get; set; }


    }

    [JsonObject]
    public class ListenNowAlbumId
    {
        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("metajamCompactKey")]
        public string MetajamCompactKey { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}