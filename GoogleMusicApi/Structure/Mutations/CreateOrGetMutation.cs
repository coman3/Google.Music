using Newtonsoft.Json;

namespace GoogleMusicApi.Structure.Mutations
{
    public class CreateOrGetMutation : Mutation
    {
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("imageType")]
        public int ImageType { get; set; }

        [JsonProperty("inLibary")]
        public bool InLibary { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("recentTimestamp")]
        public string RecentTimestamp { get; set; }

        [JsonProperty("seed")]
        public StationSeed Seed { get; set; }
    }
}