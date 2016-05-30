using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace GoogleMusicApi.Requests
{
    public class GetStreamUrl : StructuredRequest<StreamUrlGetRequest, Uri>
    {
        public override string RelativeRequestUrl => "https://android.clients.google.com/music/mplay";

        
        public GetStreamUrl()
        {
            IsCustomResponse = true;
        }

        protected override Uri ProcessReponse(HttpResponseMessage message)
        {
            if (message.StatusCode == HttpStatusCode.RedirectMethod || message.StatusCode == HttpStatusCode.Redirect ||
                message.StatusCode == HttpStatusCode.RedirectKeepVerb)
            {
                return message.Headers.Location;
            }
            return null;
        }

        protected override string GetRequestUrl(StreamUrlGetRequest request)
        {
            return "https://android.clients.google.com/music/mplay" + GetParams(request);
        }
    }
}