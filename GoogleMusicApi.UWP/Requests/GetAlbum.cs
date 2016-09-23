using GoogleMusicApi.UWP.Sessions;
using GoogleMusicApi.UWP.Structure;

namespace GoogleMusicApi.UWP.Requests
{
    public class GetAlbum : StructuredRequest<GetAlbumRequest, Album>
    {
        public override string RelativeRequestUrl => "fetchalbum";
    }

    public class GetAlbumRequest : GetRequest
    {
        public string AlbumId { get; set; }
        public bool IncludeDescription { get; set; }
        public bool IncludeTracks { get; set; }

        public GetAlbumRequest(Session session, Album album) : this(session, album.AlbumId)
        {
        }

        public GetAlbumRequest(Session session, string albumId) : base(session)
        {
            AlbumId = albumId;
        }

        public override WebRequestHeaders GetUrlContent()
        {
            UrlData.Add(new WebRequestHeader("nid", AlbumId));
            UrlData.Add(new WebRequestHeader("include-tracks", IncludeTracks.ToString()));
            UrlData.Add(new WebRequestHeader("include-description", IncludeDescription.ToString()));
            return base.GetUrlContent();
        }
    }
}