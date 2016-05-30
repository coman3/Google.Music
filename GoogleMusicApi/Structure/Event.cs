using GoogleMusicApi.Requests;
using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class Event
    {
        [JsonProperty("createdTimestampMillis")]
        public string CreatedTimestampMillis { get; set; }

        [JsonProperty("details")]
        public EventDetail Details { get; set; }

        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("trackId")]
        public MetaJamEventData TrackId { get; set; }


    }


    public class MetaJamEventData
    {
        [JsonProperty("metajamComapctKey")]
        public string MetajamComapctKey { get; set; }
    }


    public class EventDetail
    {
        [JsonProperty("rating")]
        public Rating Rating { get; set; }
    }
}