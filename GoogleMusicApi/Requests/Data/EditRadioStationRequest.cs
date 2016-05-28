using System.Collections.Generic;
using System.Text;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EditRadioStationRequest : PostRequest
    {
        [JsonProperty("mutations")]
        public EditRadioStationRequestMutation[] Mutations { get; set; }


        public EditRadioStationRequest(Session session, params EditRadioStationRequestMutation[] mutations) : base(session)
        {
            Mutations = mutations;
            Headers = new WebRequestHeaders
            {
                new KeyValuePair<string, string>("X-Device-ID", ((MobileSession)session).AndroidId)
            };
            UrlData = new WebRequestHeaders
            {
                new KeyValuePair<string, string>("alt", "json"),
                new KeyValuePair<string, string>("hl", "en_AU"),
            };
        }

        public override byte[] GetRequestBody()
        {
            var json = JsonConvert.SerializeObject(this);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}