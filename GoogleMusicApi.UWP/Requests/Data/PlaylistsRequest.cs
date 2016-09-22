using GoogleMusicApi.Sessions;
using GoogleMusicApi.Structure.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleMusicApi.Requests.Data
{
    public class PlaylistsRequest : PostRequest
    {
        [JsonProperty("creationTimestamp")]
        public string CreationTimestamp { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("lastModifiedTimestamp")]
        public string LastModifiedTimestamp { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shareState")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ShareState ShareState { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PlaylistType Type { get; set; }


        public PlaylistsRequest(Session session) : base(session)
        {
        }
    }
}