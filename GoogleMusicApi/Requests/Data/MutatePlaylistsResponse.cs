using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class MutatePlaylistsResponse
    {
        [JsonProperty("mutate_response")]
        public MutatePlaylistsResponseMutation[] ResponseMutation { get; set; }
    }
}