using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
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