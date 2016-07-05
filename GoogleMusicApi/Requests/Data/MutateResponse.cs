using GoogleMusicApi.Structure.Mutations;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class MutateResponse
    {
        [JsonProperty("mutate_response")]
        public ResponseMutation[] ResponseMutation { get; set; }
    }
}