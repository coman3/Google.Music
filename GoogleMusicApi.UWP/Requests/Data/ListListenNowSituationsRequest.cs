using GoogleMusicApi.Sessions;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
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
            SituationType = new[] { 1 };
            RequestSignals = new RequestSignal(RequestSignal.GetTimeZoneOffsetSecs());
        }
    }
}