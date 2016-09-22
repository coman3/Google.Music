using GoogleMusicApi.Sessions;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class IsPlaylistShared : StructuredRequest<IsPlaylistSharedRequest, IsPlaylistSharedResponse>
    {
        public override string RelativeRequestUrl => "isplaylistshared";
    }

    public class IsPlaylistSharedResponse
    {
        [JsonProperty("is_shared")]
        public bool IsPlaylistShared { get; set; }
    }

    public class IsPlaylistSharedRequest : GetRequest
    {
        public string PlaylistId { get; set; }
        public IsPlaylistSharedRequest(Playlist playlist, Session session) : base(session)
        {
            PlaylistId = playlist.Id;
        }

        public override WebRequestHeaders GetUrlContent()
        {
            UrlData.Add(new WebRequestHeader("id", PlaylistId));
            return base.GetUrlContent();
        }
    }
}