using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class EventResult
    {
        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

    }
}