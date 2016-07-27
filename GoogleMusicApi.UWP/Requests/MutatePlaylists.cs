using GoogleMusicApi.UWP.Requests.Data;

namespace GoogleMusicApi.UWP.Requests
{
    public class MutatePlaylists : StructuredRequest<MutateRequest, MutateResponse>
    {
        public override string RelativeRequestUrl => "playlistbatch";
    }
}