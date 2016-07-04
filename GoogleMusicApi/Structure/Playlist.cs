using GoogleMusicApi.Structure.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Playlist
    {
        [JsonProperty("accessControlled")]
        public bool AccessControlled { get; set; }

        [JsonProperty("albumArtRef")]
        public ArtReference[] AlbumArtRef { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("creationTimestamp")]
        public string CreationTimestamp { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("explicitType")]
        public string ExplicitType { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lastModifiedTimestamp")]
        public string LastModifiedTimestamp { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ownerName")]
        public string OwnerName { get; set; }

        [JsonProperty("ownerProfilePhotoUrl")]
        public string OwnerProfilePhotoUrl { get; set; }

        [JsonProperty("recentTimestamp")]
        public string RecentTimestamp { get; set; }

        [JsonProperty("shareState")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ShareState ShareState { get; set; }

        [JsonProperty("shareToken")]
        public string ShareToken { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PlaylistType PlaylistType { get; set; }

        public override string ToString()
        {
            return string.Join(" ", "Name:", Name);
        }
    }
}