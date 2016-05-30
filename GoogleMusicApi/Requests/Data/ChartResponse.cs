using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class ChartResponse
    {
        [JsonProperty("chart")]
        public Chart Chart { get; set; }

    }
}