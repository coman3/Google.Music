using Newtonsoft.Json;

namespace GoogleMusicApi.Structure.Mutations
{
    public abstract class Mutation
    {
        [JsonProperty("creationTimestamp")]
        public string CreationTimestamp { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("lastModifiedTimestamp")]
        public string LastModifiedTimestamp { get; set; }
    }
}