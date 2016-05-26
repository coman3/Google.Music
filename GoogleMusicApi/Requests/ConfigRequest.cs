using System.Collections.Generic;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ConfigRequest : StructuredRequest<GetRequest, Config>
    {
        public override string RelativeRequestUrl => "config";

        public override string GetRequestUrl(Request request)
        {
            request.UrlData = new WebRequestHeaders
            {
                new KeyValuePair<string, string>("dv", 0.ToString())
            };
            return base.GetRequestUrl(request);
        }
    }
}