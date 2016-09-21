using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GoogleMusicApi.UWP.Sessions;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP
{
    public abstract class StructuredRequest
    {
        public const string BaseApiUrl = "https://mclients.googleapis.com/sj/v2.5/";
        public abstract string RelativeRequestUrl { get; }
    }

    public abstract class StructuredRequest<TRequest, TResponse> : StructuredRequest
        where TRequest : Request
    {
        private JsonSerializer Serializer { get; set; }

        protected StructuredRequest()
        {
            // Uses Custom serializer class so we can see if there are any missing fields from the json to object translation,
            // Only will throw an error in DUBUG!
            Serializer = new JsonSerializer();
#if DEBUG
            Serializer.MissingMemberHandling = MissingMemberHandling.Error;
#endif
        }

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
            using (data) // so you cant use the same request twice, after we are finished dispose it.
            {
                if (data.Method == RequestMethod.GET)
                {
                    using (var response = await data.Session.HttpClient.GetAsync(requestUrl))
                    {
                        if (IsCustomResponse)
                            return await ProcessReponse(response);

                        response.EnsureSuccessStatusCode();
                        var json = await response.Content.ReadAsStringAsync();

                        return Serializer.Deserialize<TResponse>(new JsonTextReader(new StringReader(json)));
                    }
                }

                if (data is PostRequest || data is PutRequest)
                {
                    var postRequest = data as PostRequest;
                    var putRequest = data as PutRequest;
                    HttpResponseMessage response;

                    if (data.Method == RequestMethod.POST && postRequest != null)
                        response = await data.Session.HttpClient.PostAsync(requestUrl, postRequest.GetRequestContent());
                    else if (data.Method == RequestMethod.PUT && putRequest != null)
                        response = await data.Session.HttpClient.PutAsync(requestUrl, putRequest.GetRequestContent());
                    else return default(TResponse);

                    if (IsCustomResponse)
                        return await ProcessReponse(response);

                    response.EnsureSuccessStatusCode();
                    var json = await response.Content.ReadAsStringAsync();

                    return Serializer.Deserialize<TResponse>(new JsonTextReader(new StringReader(json)));

                }
            }
            return default(TResponse);
        }

        protected virtual string GetRequestUrl(TRequest request)
        {
            var urlParams = GetParams(request);

            var putRequest = request as PutRequest;
            if (putRequest != null)
            {
                return BaseApiUrl + RelativeRequestUrl + "/" + putRequest.Id + urlParams;
            }

            return BaseApiUrl + RelativeRequestUrl + urlParams;
        }

        protected virtual Task<TResponse> ProcessReponse(HttpResponseMessage message)
        {
            throw new InvalidOperationException($"Please override {nameof(ProcessReponse)} when {nameof(IsCustomResponse)} is true.");
        }

        protected static string GetParams(TRequest request)
        {
            var urlParams = "";
            if (request.UrlData == null)
                return urlParams; // Add no Url data

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