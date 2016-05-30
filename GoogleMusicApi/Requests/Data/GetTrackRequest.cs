using GoogleMusicApi.Sessions;

namespace GoogleMusicApi.Requests.Data
{
    public class GetTrackRequest : GetRequest
    {
        public string TrackId { get; set; }

        public GetTrackRequest(Session session, string trackId) : base(session)
        {
            TrackId = trackId;
        }

        public override WebRequestHeaders GetUrlContent()
        {
            UrlData.Add(new WebRequestHeader("nid", TrackId));
            return base.GetUrlContent();
        }
    }
}