using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace GoogleMusicApi
{
    public class ParsedRequest
    {
        public string Url { get; set; }
        public RequestMethod Method { get; set; }
        public int? ContentLength => ContentData?.Length;
        public byte[] ContentData { get; set; }
        public string ContentType { get; set; }
        public string Accept { get; set; }
        public string UserAgent { get; set; }
        public WebRequestHeaders Headers { get; set; }

        public ParsedRequest(string authToken, RequestMethod method)
            : this(method,
                new WebRequestHeaders(new KeyValuePair<string, string>("Authorization", "GoogleLogin auth=" + authToken)))
        {
        }

        public ParsedRequest(RequestMethod method, WebRequestHeaders headers = null)
        {
            Headers = headers ?? new WebRequestHeaders();
            Method = method;
            ContentType = "application/json";
            Accept = "application/json";
            UserAgent = GoogleAuth.GoogleAuth.UserAgent;

        }

        public ParsedRequest(string authToken, Request request) : this(authToken, request.Method)
        {
            if (request is PostRequest)
            {
                ContentData = ((PostRequest) request).GetRequestBody();
            }
            if (request.Headers?.Count > 0)
            {
                foreach (var header in request.Headers)
                {
                    Headers.Add(header);
                }
            }
            Accept = request.Accept;
        }


        public HttpWebRequest GetWebRequest()
        {

            var request = (HttpWebRequest) WebRequest.Create(Url);
            foreach (var header in Headers)
            {
                request.Headers[header.Key] = header.Value;
            }
            request.Accept = Accept;
            request.UserAgent = UserAgent;
            request.Method = "GET";

            if (Method != RequestMethod.POST || !ContentLength.HasValue) return request;

            request.Method = "POST";
            request.ContentType = ContentType;
            request.ContentLength = ContentLength.Value;

            var requestStream = request.GetRequestStream();
            requestStream.Write(ContentData, 0, ContentLength.Value);
            requestStream.Close();

            return request;
        }
        public async Task<HttpWebRequest> GetWebRequestAsync()
        {
            return await Task.Factory.StartNew(GetWebRequest);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public enum RequestMethod
        {

            POST,
            GET,
        }
    }
}