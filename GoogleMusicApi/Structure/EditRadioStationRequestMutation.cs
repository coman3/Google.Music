using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class EditRadioStationRequestMutation
    {
        [JsonProperty("createOrGet")]
        public EditRadioStationRequestCreateOrGetMutation CreateOrGet { get; set; }

        public Track[] Tracks { get; set; }

        [JsonProperty("includeFeed")]
        public bool IncludeFeed { get; set; }

        [JsonProperty("numEntries")]
        public int NumberOfEntries { get; set; }

        [JsonProperty("params")]
        public EditRadioStationRequestParameters Parameters { get; set; }

    }
}