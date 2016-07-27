using GoogleMusicApi.UWP.Sessions;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FeedRequest : ResultListRequest
    {

        public string UpdatedMin { get; set; }
        public bool NewResultsExpected { get; set; }
        public FeedRequest(Session session) : base(session)
        {
        }

        public override WebRequestHeaders GetUrlContent()
        {
            UrlData.Add(new WebRequestHeader("updated-min", UpdatedMin));
            UrlData.Add(new WebRequestHeader("new-results-expected", NewResultsExpected.ToString().ToLower()));
            return base.GetUrlContent();
        }
    }
}