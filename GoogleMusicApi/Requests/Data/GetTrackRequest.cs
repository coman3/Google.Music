namespace GoogleMusicApi.Requests
{
    public class GetTrackRequest : GetRequest
    {
        public GetTrackRequest(Session session, string trackId) : base(session)
        {
            TrackId = trackId;
        }

        public string TrackId { get; set; }
    }
}