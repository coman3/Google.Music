using GoogleMusicApi.UWP.Sessions;
using GoogleMusicApi.UWP.Structure.Mutations;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EditRadioStationRequest : PostRequest
    {
        [JsonProperty("mutations")]
        public EditRadioStationMutate[] Mutations { get; set; }

        public EditRadioStationRequest(Session session, params EditRadioStationMutate[] mutations)
                    : base(session)
        {
            Mutations = mutations;
        }
    }
}