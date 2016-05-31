using GoogleMusicApi.Sessions;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace GoogleMusicApi
{
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

        public virtual HttpContent GetRequestContent()
        {
            return BuildHttpContent(this);
        }

        protected static HttpContent BuildHttpContent(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }

    public abstract class Request : IDisposable
    {
        public string Locale { get; set; }

        public RequestMethod Method { get; }

        public Session Session { get; set; }

        public WebRequestHeaders UrlData { get; set; }

        public bool UseCustomHeaders { get; set; }

        protected Request(Session session, RequestMethod method)
        {
            if (session == null) throw new ArgumentException("Must have valid session", nameof(session));
            Locale = "en_US";
            Method = method;
            Session = session;
            UrlData = new WebRequestHeaders(
                new WebRequestHeader("alt", "json"),
                new WebRequestHeader("hl", Locale));
        }

        public void Dispose()
        {
            UrlData = null;
            Session = null;
        }

        public virtual WebRequestHeaders GetUrlContent()
        {
            return UrlData;
        }

        public virtual void SetHeaders(HttpRequestHeaders headers)
        {
            throw new InvalidOperationException($"Please override {nameof(SetHeaders)} if {nameof(UseCustomHeaders)} is true.");
        }
    }
}