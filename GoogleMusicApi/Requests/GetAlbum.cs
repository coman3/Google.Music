using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class GetAlbum : StructuredRequest<GetAlbumRequest, Album>
    {
        public override string RelativeRequestUrl => "fetchalbum";

        protected override ParsedRequest GetParsedRequest(GetAlbumRequest request)
        {
            request.UrlData.Add(new WebRequestHeader("nid", request.AlbumId));
            request.UrlData.Add(new WebRequestHeader("include-tracks", request.IncludeTracks.ToString()));
            request.UrlData.Add(new WebRequestHeader("include-description", request.IncludeDescription.ToString()));
            return base.GetParsedRequest(request);
        }
    }

    public class GetAlbumRequest : GetRequest
    {
        public bool IncludeTracks { get; set; }
        public bool IncludeDescription { get; set; }
        public string AlbumId { get; set; }

        public GetAlbumRequest(Session session, Album album) : this(session, album.AlbumId)
        {
            
        }
        public GetAlbumRequest(Session session, string albumId) : base(session)
        {
            UrlData.Add(new WebRequestHeader("alt", "json"));
            UrlData.Add(new WebRequestHeader("hl", "en_AU"));
            AlbumId = albumId;
        }
    }
}
