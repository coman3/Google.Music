using System;
using System.IO;
using System.Security.Authentication;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoogleMusicApi
{
    public abstract class StructuredRequest
    {
        public const string BaseApiUrl = "https://mclients.googleapis.com/sj/v2.4/";
        public abstract string RelativeRequestUrl { get; }
    }

    public abstract class StructuredRequest<TRequest, TResponse> : StructuredRequest
        where TRequest : Request
    {
        public virtual TResponse Get(TRequest data)
        {
            var request = GetParsedRequest(data);
            var webRequest = request.GetWebRequest();
            var response = webRequest.GetResponse();

            // ReSharper disable once AssignNullToNotNullAttribute
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var json = reader.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<TResponse>(json);
                return obj;
            }
        }

        public virtual async Task<TResponse> GetAsync(TRequest data)
        {
            return await Task.Factory.StartNew(() => Get(data));
        }

        protected virtual ParsedRequest GetParsedRequest(TRequest request)
        {
            if (!request.Session.IsAuthenticated) throw new AuthenticationException("Not authenticated");
            if (!(request.Session is MobileSession))
                throw new NotSupportedException("Only a Mobile Session is supported");
            var mobileSession = (MobileSession) request.Session;

            return new ParsedRequest(mobileSession.AuthorizationToken, request)
            {
                Url = GetRequestUrl(request)
            };
        }

        protected virtual string GetRequestUrl(TRequest request)
        {
            var urlParams = GetParams(request);
            return BaseApiUrl + RelativeRequestUrl + urlParams;
        }


        protected static string GetParams(TRequest request)
        {
            var urlParams = "";
            if (request?.UrlData == null) return null; //if not GetRe

            var first = true;
            foreach (var pair in request.UrlData)
            {
                if (first)
                {
                    urlParams += "?";
                    first = false;
                }
                else urlParams += "&";
                urlParams += pair.Key + "=" + pair.Value;
            }

            return urlParams;
        }
    }
}