using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Station
    {
        [JsonProperty("compositeArtRefs")]
        public ArtReference[] CompositeArtRefs { get; set; }

        [JsonProperty("contentTypes")]
        public string[] ContentTypes { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("imageUrls")]
        public ArtReference[] ImageUrls { get; set; }

        //TODO: Line:  Extream
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lastModifiedTimestamp")]
        public string LastModifiedTimestamp { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("recentTimestamp")]
        public string RecentTimestamp { get; set; }

        [JsonProperty("seed")]
        public StationSeed Seed { get; set; }

        [JsonProperty("skipEventHistory")]
        public string[] SkipEventHistory { get; set; } //TODO: What is this?

        [JsonProperty("stationSeeds")]
        public StationSeed[] StationSeeds { get; set; }

        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("inLibrary")]
        public bool InLibrary { get; set; }


        public override string ToString()
        {
            return string.Join(" ", "Name:", Name);
        }
    }
}