namespace GoogleMusicApi.Requests
{
    public class SearchGetRequest : GetRequest
    {
        public string Query { get; set; }

        public SearchGetRequest(Session session, string query) : base(session)
        {
            Query = query;
        }
    }
}