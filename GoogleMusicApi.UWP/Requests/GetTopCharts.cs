using GoogleMusicApi.UWP.Requests.Data;

namespace GoogleMusicApi.UWP.Requests
{
    public class GetTopCharts : StructuredRequest<GetRequest, ChartResponse>
    {
        public override string RelativeRequestUrl => "browse/topchart";
    }
}