using System.IO;
using System.Net.Http;
using System.Text;
using GoogleMusicApi.UWP.Sessions;
using GoogleMusicApi.UWP.Structure.Mutations;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MutateRequest : PostRequest
    {
        [JsonProperty("mutations")]
        public Mutate[] Mutations { get; set; }


        public MutateRequest(Session session) : base(session)
        {
        }

        public override HttpContent GetRequestContent()
        {
            var serilizer = new JsonSerializer();
            serilizer.NullValueHandling = NullValueHandling.Ignore;
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                serilizer.Serialize(sw, this);
            }
            
            return new StringContent(sb.ToString(), Encoding.UTF8, "application/json");
        }
    }
}