using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class EventResult
    {
        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

    }
}