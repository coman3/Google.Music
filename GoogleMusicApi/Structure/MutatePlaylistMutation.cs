using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class MutatePlaylistMutation
    {
        [JsonProperty("delete")]
        public string Delete { get; set; }
        //TODO: What else?
    }
}