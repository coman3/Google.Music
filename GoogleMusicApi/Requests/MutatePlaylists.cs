using GoogleMusicApi.Requests.Data;

namespace GoogleMusicApi.Requests
{
    public class MutatePlaylists : StructuredRequest<MutateRequest, MutateResponse>
    {
        public override string RelativeRequestUrl => "playlistbatch";
    }
}