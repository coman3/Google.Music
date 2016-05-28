using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class ListStationsResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("stations")]
        public Station[] Stations { get; set; }

    }
}