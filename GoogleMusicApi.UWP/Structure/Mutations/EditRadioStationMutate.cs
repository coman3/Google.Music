using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure.Mutations
{
    public class EditRadioStationMutate
    {
        [JsonProperty("createOrGet")]
        public CreateOrGetMutation CreateOrGet { get; set; }

        [JsonProperty("includeFeed")]
        public bool IncludeFeed { get; set; }

        [JsonProperty("numEntries")]
        public int NumberOfEntries { get; set; }

        [JsonProperty("params")]
        public EditRadioStationRequestParameters Parameters { get; set; }

        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }

        public class EditRadioStationRequestParameters
        {
            [JsonProperty("contentFilter")]
            public int ContentFilter { get; set; }
        }

    }
}