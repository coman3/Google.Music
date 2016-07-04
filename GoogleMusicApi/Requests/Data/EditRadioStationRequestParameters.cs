using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class EditRadioStationRequestParameters
    {
        [JsonProperty("contentFilter")]
        public int ContentFilter { get; set; }
    }
}