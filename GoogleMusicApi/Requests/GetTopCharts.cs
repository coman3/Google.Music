using GoogleMusicApi.Requests.Data;

namespace GoogleMusicApi.Requests
{
    public class GetTopCharts : StructuredRequest<GetRequest, ChartResponse>
    {
        public override string RelativeRequestUrl => "browse/topchart";
    }
}