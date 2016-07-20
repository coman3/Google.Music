using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure.Mutations
{
    public class EditRadioStationReponseMutation : ResponseMutation
    {
        [JsonProperty("inLibary")]
        public bool InLibary { get; set; }
        
        [JsonProperty("skipEventHistory")]
        public object[] SkipEventHistory { get; set; }

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }

        //TODO (Low): Find out what this type is
    }
}