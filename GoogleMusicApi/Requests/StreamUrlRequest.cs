namespace GoogleMusicApi.Requests
{
    public class StreamUrlRequest : StructuredRequest<StreamUrlGetRequest, string>
    {
        
        public override string RelativeRequestUrl => "music/mplay";

        public override string Get(StreamUrlGetRequest data)
        {
            var request = GetParsedRequest(data);
            var webRequest = request.GetWebRequest();
            webRequest.AllowAutoRedirect = false;
            var response = webRequest.GetResponse();

            // ReSharper disable once AssignNullToNotNullAttribute
            if (response.Headers.Get("location") != null)
            {
                return response.Headers.Get("location");
            }
            return null;
        }

        public override string GetRequestUrl(Request request)
        {
            return "https://android.clients.google.com/music/mplay" + GetParams(request);
        }
    }
}