using GoogleMusicApi.UWP.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests
{
    public class GetTopChartGenres : StructuredRequest<GetRequest, GetTopChartGenresResponse>
    {
        public override string RelativeRequestUrl => "browse/topchartgenres";
    }

    public class GetTopChartGenresResponse
    {
        [JsonProperty("genres")]
        public Genre[] Genres { get; set; }
    }
}