using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class MutatePlaylistMutation
    {
        [JsonProperty("delete")]
        public string Delete { get; set; }
        //TODO: What else?
    }
}