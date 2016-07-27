using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GoogleMusicApi.UWP.Requests.Data;

namespace GoogleMusicApi.UWP.Requests
{
    public class GetStreamUrl : StructuredRequest<StreamUrlGetRequest, Uri>
    {
        public override string RelativeRequestUrl => "https://android.clients.google.com/music/mplay";

        public GetStreamUrl()
        {
            IsCustomResponse = true;
        }

        protected override string GetRequestUrl(StreamUrlGetRequest request)
        {
            return "https://android.clients.google.com/music/mplay" + GetParams(request);
        }

        protected override async Task<Uri> ProcessReponse(HttpResponseMessage message)
        {
            if (message.StatusCode == HttpStatusCode.RedirectMethod || message.StatusCode == HttpStatusCode.Redirect ||
                message.StatusCode == HttpStatusCode.RedirectKeepVerb || message.StatusCode == HttpStatusCode.OK)
            {
                var data = await message.Content.ReadAsStringAsync();
                return message.Headers.Location;
            }
            return null;
        }
    }
}