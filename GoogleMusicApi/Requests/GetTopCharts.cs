namespace GoogleMusicApi.Requests
{
    public class GetTopCharts : StructuredRequest<GetRequest, ChartResponse>
    {
        public override string RelativeRequestUrl => "browse/topchart";

        protected override ParsedRequest GetParsedRequest(GetRequest request)
        {
            request.UrlData.Add(new WebRequestHeader("alt", "json"));
            request.UrlData.Add(new WebRequestHeader("hl", "en_AU")); //TODO (Low): Implement Locals from the GetRequest
            return base.GetParsedRequest(request);
        }
    }
}