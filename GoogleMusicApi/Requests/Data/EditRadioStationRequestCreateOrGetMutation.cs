using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class EditRadioStationRequestCreateOrGetMutation
    {
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("imageType")]
        public int ImageType { get; set; }

        [JsonProperty("inLibary")]
        public bool InLibary { get; set; }

        [JsonProperty("lastModifiedTimestamp")]
        public string LastModifiedTimestamp { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("recentTimestamp")]
        public string RecentTimestamp { get; set; }

        [JsonProperty("seed")]
        public StationSeed Seed { get; set; }
    }
}