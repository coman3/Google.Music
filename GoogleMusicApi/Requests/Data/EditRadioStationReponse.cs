using GoogleMusicApi.Structure;
using GoogleMusicApi.Structure.Mutations;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class EditRadioStationReponse
    {
        [JsonProperty("mutate_response")]
        public EditRadioStationReponseMutation[] MutateReponse { get; set; }

        [JsonProperty("currentTimestampMillis")]
        public string CurrentTimestampMillis { get; set; }


    }
}