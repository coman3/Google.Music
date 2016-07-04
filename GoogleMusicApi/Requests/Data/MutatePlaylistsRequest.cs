using GoogleMusicApi.Sessions;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests.Data
{
    public class MutatePlaylistsRequest : PostRequest
    {
        [JsonProperty("mutations")]
        public MutatePlaylistMutation[] Mutations { get; set; }


        public MutatePlaylistsRequest(Session session) : base(session)
        {
        }
    }
}