using GoogleMusicApi.UWP.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    public class ChartResponse
    {
        [JsonProperty("chart")]
        public Chart Chart { get; set; }
    }
}