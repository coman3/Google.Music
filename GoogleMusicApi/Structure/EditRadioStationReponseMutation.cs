using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class EditRadioStationReponseMutation
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("inLibary")]
        public bool InLibary { get; set; }

        [JsonProperty("reponse_code")]
        public string ResponseCode { get; set; }

        [JsonProperty("skipEventHistory")]
        public object[] SkipEventHistory { get; set; }

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }

        //TODO (Low): Find out what this type is
    }
}