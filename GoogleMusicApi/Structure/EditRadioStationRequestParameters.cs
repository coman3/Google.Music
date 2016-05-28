using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class EditRadioStationRequestParameters
    {
        [JsonProperty("contentFilter")]
        public int ContentFilter { get; set; }
    }
}