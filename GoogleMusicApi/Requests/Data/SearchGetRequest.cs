namespace GoogleMusicApi.Requests
{
    public class SearchGetRequest : GetRequest
    {
        public SearchGetRequest(Session session, string query) : base(session)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}