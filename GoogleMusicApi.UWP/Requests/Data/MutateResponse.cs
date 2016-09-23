using GoogleMusicApi.UWP.Structure.Mutations;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    public class MutateResponse
    {
        [JsonProperty("mutate_response")]
        public ResponseMutation[] ResponseMutation { get; set; }
    }
}