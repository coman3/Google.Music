using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure.Mutations
{
    public class CreateMutation : Mutation
    {
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("playlistId")]
        public string PlaylistId { get; set; }

        [JsonProperty("source")]
        public int Source { get; set; }

        [JsonProperty("trackId")]
        public string TrackId { get; set; }

    }
}