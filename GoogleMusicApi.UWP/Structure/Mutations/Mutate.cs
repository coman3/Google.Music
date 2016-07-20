using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure.Mutations
{
    public class Mutate
    {
        [JsonProperty("create")]
        public Mutation Create { get; set; }

        [JsonProperty("delete")]
        public string Delete { get; set; }

    }
}