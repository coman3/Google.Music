using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    public class RecordRealTimeResponse
    {
        [JsonProperty("eventResults")]
        public EventResult[] EventResults { get; set; }
    }
}