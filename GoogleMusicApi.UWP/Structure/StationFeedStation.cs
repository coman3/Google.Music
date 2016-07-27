using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure
{
    public class StationFeedStation
    {
        [JsonProperty("libraryContentOnly")]
        public bool LibraryContentOnly { get; set; }

        [JsonProperty("numEntries")]
        public int NumberOfEntries { get; set; }

        [JsonProperty("recentlyPlayed")]
        public Track[] RecentlyPlayed { get; set; }

        [JsonProperty("seed")]
        public StationSeed Seed { get; set; }

    }
}