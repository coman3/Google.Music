using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
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
        protected bool IsCustomResponse = false;
        public virtual async Task<TResponse> GetAsync(TRequest data)
        {
            if (data.UseCustomHeaders)
            {
                data.Session.HttpClient.DefaultRequestHeaders.Clear();
                data.SetHeaders(data.Session.HttpClient.DefaultRequestHeaders);
            }
            else data.Session.ResetHeaders();
            data.UrlData = data.GetUrlContent();
            var requestUrl = GetRequestUrl(data);
            if (data.Method == RequestMethod.GET)
            {
                
                using (var response = await data.Session.HttpClient.GetAsync(requestUrl))
                {
                    if (IsCustomResponse)
                        return await ProcessReponse(response);

                    response.EnsureSuccessStatusCode();
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResponse>(json);
                }
            }

            if (data.Method == RequestMethod.POST && data is PostRequest)
            {
                var postRequest = data as PostRequest;
                using (var response = await data.Session.HttpClient.PostAsync(requestUrl, postRequest.GetRequestContent()))
                {
                    if (IsCustomResponse)
                        return await ProcessReponse(response);

                    response.EnsureSuccessStatusCode();
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResponse>(json);
                }
            }
            return default(TResponse);
        }

        protected virtual string GetRequestUrl(TRequest request)
        {
            var urlParams = GetParams(request);
            return BaseApiUrl + RelativeRequestUrl + urlParams;
        }

        protected virtual Task<TResponse> ProcessReponse(HttpResponseMessage message)
        {
            throw new InvalidOperationException($"Please override {nameof(ProcessReponse)} when {nameof(IsCustomResponse)} is true.");
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