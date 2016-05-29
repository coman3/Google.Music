using System;
using System.Collections.Generic;
using System.Text;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ListListenNowSituationsRequest : PostRequest
    {
        [JsonProperty("requestSignals")]
        public RequestSignal RequestSignals { get; set; }

        [JsonProperty("situationType")]
        public int[] SituationType { get; set; }


        public ListListenNowSituationsRequest(Session session) : base(session)
        {
            UrlData.Add(new KeyValuePair<string, string>("alt", "json"));
            UrlData.Add(new KeyValuePair<string, string>("hl", "en_AU"));
            Headers.Add(new KeyValuePair<string, string>("X-Device-ID", ((MobileSession)session).AndroidId));
        }

        public override byte[] GetRequestBody()
        {
            SituationType = new[] {1};
            RequestSignals = new RequestSignal();
            RequestSignals.TimeZoneOffsetSecs = (int)(DateTime.Now - DateTime.UtcNow).TotalSeconds;
            var json = JsonConvert.SerializeObject(this);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}