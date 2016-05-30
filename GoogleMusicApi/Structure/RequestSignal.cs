using Newtonsoft.Json;
using System;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class RequestSignal
    {
        [JsonProperty("timeZoneOffsetSecs")]
        public int TimeZoneOffsetSecs { get; set; }

        public RequestSignal()
        {
        }

        public RequestSignal(int timeZoneOffsetSecs)
        {
            TimeZoneOffsetSecs = timeZoneOffsetSecs;
        }

        public static int GetTimeZoneOffsetSecs()
        {
            return (int)(DateTime.Now - DateTime.UtcNow).TotalSeconds;
        }
    }
}