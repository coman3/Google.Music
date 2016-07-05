using GoogleMusicApi.Structure.Enums;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class EventResult
    {
        [JsonProperty("code")]
        public ResponseCode Code { get; set; }

        [JsonProperty("eventId")]
        public string EventId { get; set; }
    }
}