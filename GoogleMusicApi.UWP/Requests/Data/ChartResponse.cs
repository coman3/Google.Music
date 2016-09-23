using GoogleMusicApi.UWP.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    public class ChartResponse
    {
        [JsonProperty("chart")]
        public Chart Chart { get; set; }

        [JsonProperty("header")]
        public ChartHeader Header { get; set; }
    }

    public class ChartHeader
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("header_image")]
        public ArtReference HeaderImage { get; set; }
    }
}