using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class RecordRealTimeResponse
    {
        [JsonProperty("eventResults")]
        public EventResult[] EventResults { get; set; }

    }
}