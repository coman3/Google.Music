using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class RecordRealTimeResponse
    {
        [JsonProperty("eventResults")]
        public EventResult[] EventResults { get; set; }

    }
}