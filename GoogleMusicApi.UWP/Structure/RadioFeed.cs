using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RadioFeed
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public FeedData Data { get; set; }


        public class FeedData
        {
            [JsonProperty("stations")]
            public Station[] Stations { get; set; }

            [JsonProperty("currentTimestampMillis")]
            public string CurrentTimestampMillis { get; set; }


        }


    }
}