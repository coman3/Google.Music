using System.Collections.Generic;
using System.Text;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EditRadioStationRequest : PostRequest
    {
        public EditRadioStationRequest(Session session, params EditRadioStationRequestMutation[] mutations)
            : base(session)
        {
            Mutations = mutations;
            Headers = new WebRequestHeaders
            {
                new WebRequestHeader("X-Device-ID", ((MobileSession) session).AndroidId)
            };
            UrlData = new WebRequestHeaders
            {
                new WebRequestHeader("alt", "json"),
                new WebRequestHeader("hl", "en_AU")
            };
        }

        [JsonProperty("mutations")]
        public EditRadioStationRequestMutation[] Mutations { get; set; }

        public override byte[] GetRequestBody()
        {
            var json = JsonConvert.SerializeObject(this);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}