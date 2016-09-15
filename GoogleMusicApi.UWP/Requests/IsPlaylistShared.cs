using GoogleMusicApi.UWP.Sessions;
using GoogleMusicApi.UWP.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests
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