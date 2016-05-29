using System.Collections.Generic;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class GetConfig : StructuredRequest<GetRequest, Config>
    {
        public override string RelativeRequestUrl => "config";

        protected override ParsedRequest GetParsedRequest(GetRequest request)
        {
            request.UrlData.Add(new WebRequestHeader("dv", 0.ToString()));

            return base.GetParsedRequest(request);
        }
    }
}