using System.Collections.Generic;

namespace GoogleMusicApi
{
    public abstract class Request
    {
        public Session Session { get; set; }
        public string Accept { get; set; }
        public ParsedRequest.RequestMethod Method { get; }
        public WebRequestHeaders UrlData { get; set; }
        public WebRequestHeaders Headers { get; set; }

        protected Request(Session session, ParsedRequest.RequestMethod method)
        {
            Method = method;
            Session = session;
            Accept = "application/json";
        }
        
    }
    public class GetRequest : Request
    {
        public GetRequest(Session session) : base(session, ParsedRequest.RequestMethod.GET)
        {

        }
    }

    public abstract class PostRequest : Request
    {
        protected PostRequest(Session session) : base(session, ParsedRequest.RequestMethod.POST)
        {

        }
        public abstract byte[] GetRequestBody();
    }
}