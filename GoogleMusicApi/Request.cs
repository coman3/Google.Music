namespace GoogleMusicApi
{
    public abstract class Request
    {
        protected Request(Session session, RequestMethod method)
        {
            UrlData = new WebRequestHeaders();
            Headers = new WebRequestHeaders();
            Method = method;
            Session = session;
            Accept = "application/json";
        }

        public Session Session { get; set; }
        public string Accept { get; set; }
        public RequestMethod Method { get; }
        public WebRequestHeaders UrlData { get; set; }
        public WebRequestHeaders Headers { get; set; }
    }

    public class GetRequest : Request
    {
        public GetRequest(Session session) : base(session, RequestMethod.GET)
        {
        }
    }

    public abstract class PostRequest : Request
    {
        protected PostRequest(Session session) : base(session, RequestMethod.POST)
        {
        }

        public abstract byte[] GetRequestBody();
    }
}