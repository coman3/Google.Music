using System;

namespace GoogleMusicApi.Common
{
    public class Time
    {
        public static string GetCurrentTimestamp()
        {
            return (DateTime.UtcNow - DateTime.Now).TotalMilliseconds.ToString("#");
        }
    }
}