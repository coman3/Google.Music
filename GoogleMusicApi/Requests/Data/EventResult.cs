using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class EventResult
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("eventId")]
        public string EventId { get; set; }
    }
}