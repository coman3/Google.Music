using System.Net;
using GoogleMusicApi.Sessions;

namespace GoogleMusicApi.Requests.Data
{
    public class SearchGetRequest : GetRequest
    {
        public int NumberOfResults { get; set; }

        public string Query { get; set; }

        public int[] ReturnTypes { get; set; }

        public SearchGetRequest(Session session, string query) : base(session)
        {
            Query = query;
            NumberOfResults = 100;
            ReturnTypes = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        }

        //TODO (Low): Get types and turn to a flag or enum array
        public override WebRequestHeaders GetUrlContent()
        {
            UrlData.Add(new WebRequestHeader("ct", WebUtility.UrlEncode(string.Join(",", ReturnTypes))));
            UrlData.Add(new WebRequestHeader("q", WebUtility.UrlEncode(Query)));
            UrlData.Add(new WebRequestHeader("max-results", NumberOfResults.ToString()));
            return base.GetUrlContent();
        }
    }
}