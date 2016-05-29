using System.Collections.Generic;
using System.Runtime.InteropServices;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ConfigRequest : StructuredRequest<GetRequest, Config>
    {
        public override string RelativeRequestUrl => "config";

        protected override ParsedRequest GetParsedRequest(Request request)
        {
            request.UrlData.Add(new KeyValuePair<string, string>("dv", 0.ToString()));

            return base.GetParsedRequest(request);
        }

        protected override string GetRequestUrl(Request request)
        {
            
            return base.GetRequestUrl(request);
        }
    }
}