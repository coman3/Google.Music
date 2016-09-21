using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Plentry
    {
        [JsonProperty("absolutePosition")]
        public string AbsolutePosition { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("creationTimestamp")]
        public string CreationTimestamp { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lastModifiedTimestamp")]
        public string LastModifiedTimestamp { get; set; }

        [JsonProperty("playlistId")]
        public string PlaylistId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("track")]
        public Track Track { get; set; }

        [JsonProperty("trackId")]
        public string TrackId { get; set; }
    }
}