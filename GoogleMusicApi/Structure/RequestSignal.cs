using System;
using System.Globalization;
using Newtonsoft.Json;

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
            return (int) (DateTime.Now - DateTime.UtcNow).TotalSeconds;
        }
    }
}