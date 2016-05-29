using System;
using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class RequestSignal
    {
        public RequestSignal()
        {
        }

        public RequestSignal(int timeZoneOffsetSecs)
        {
            TimeZoneOffsetSecs = timeZoneOffsetSecs;
        }

        [JsonProperty("timeZoneOffsetSecs")]
        public int TimeZoneOffsetSecs { get; set; }

        public static int GetTimeZoneOffsetSecs()
        {
            return (int) (DateTime.Now - DateTime.UtcNow).TotalSeconds;
        }
    }
}