using System.Collections.Generic;
using System.Net.Http;
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
        }

        [JsonProperty("mutations")]
        public EditRadioStationRequestMutation[] Mutations { get; set; }

    }
}