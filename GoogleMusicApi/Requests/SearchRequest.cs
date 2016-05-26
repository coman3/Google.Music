using System.Collections.Generic;
using System.Net;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class SearchRequest : StructuredRequest<GetRequest, SearchResponse>
    {
        public string Query { get; set; }
        public SearchRequest(string query)
        {
            Query = query;
        }
        public override string RelativeRequestUrl => "query";

        public override string GetRequestUrl(Request request)
        {
            request.UrlData = new WebRequestHeaders
            {
                new KeyValuePair<string, string>("ct", WebUtility.UrlEncode("1,2,3,4,5,6,7,8")),
                new KeyValuePair<string, string>("q", WebUtility.UrlEncode(Query)),
                new KeyValuePair<string, string>("max-results", "100"),
            };
            return base.GetRequestUrl(request);
        }
    }
}