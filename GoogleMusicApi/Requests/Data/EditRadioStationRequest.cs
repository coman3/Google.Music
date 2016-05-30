using GoogleMusicApi.Sessions;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EditRadioStationRequest : PostRequest
    {
        [JsonProperty("mutations")]
        public EditRadioStationRequestMutation[] Mutations { get; set; }

        public EditRadioStationRequest(Session session, params EditRadioStationRequestMutation[] mutations)
                    : base(session)
        {
            Mutations = mutations;
        }
    }
}