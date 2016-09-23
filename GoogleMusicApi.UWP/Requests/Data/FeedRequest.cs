using GoogleMusicApi.UWP.Sessions;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FeedRequest : ResultListRequest
    {

        public string UpdatedMin { get; set; }
        public bool NewResultsExpected { get; set; }
        public bool Refresh { get; set; }
        public FeedRequest(Session session) : base(session)
        {
        }

        public override WebRequestHeaders GetUrlContent()
        {
            UrlData.Add(new WebRequestHeader("updated-min", UpdatedMin));
            if(NewResultsExpected)
                UrlData.Add(new WebRequestHeader("new-results-expected", NewResultsExpected ? "1" : "0"));
            else if (Refresh)
                UrlData.Add(new WebRequestHeader("refresh", Refresh ? "1" : "0"));
            return base.GetUrlContent();
        }
    }
}