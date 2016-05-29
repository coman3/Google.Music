namespace GoogleMusicApi.Requests
{
    public class GetTrackRequest : GetRequest
    {
        public string TrackId { get; set; }

        public GetTrackRequest(Session session, string trackId) : base(session)
        {
            TrackId = trackId;
        }
    }
}