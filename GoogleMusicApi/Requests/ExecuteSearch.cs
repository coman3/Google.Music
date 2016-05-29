using System.Collections.Generic;
using System.Net;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ExecuteSearch : StructuredRequest<SearchGetRequest, SearchResponse>
    {
        public override string RelativeRequestUrl => "query";

        protected override ParsedRequest GetParsedRequest(SearchGetRequest request)
        {
            
            request.UrlData.Add(new KeyValuePair<string, string>("ct", WebUtility.UrlEncode("1,2,3,4,5,6,7,8")));
            request.UrlData.Add(new KeyValuePair<string, string>("q", WebUtility.UrlEncode(request.Query)));
            request.UrlData.Add(new KeyValuePair<string, string>("max-results", "100"));
            
            return base.GetParsedRequest(request);
        }
    }
}