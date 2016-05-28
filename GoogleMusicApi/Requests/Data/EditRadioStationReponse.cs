using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class EditRadioStationReponse
    {
        [JsonProperty("mutate_response")]
        public EditRadioStationReponseMutation[] MutateReponse { get; set; }
    }
}