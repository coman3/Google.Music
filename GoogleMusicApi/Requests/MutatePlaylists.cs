using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure.Mutations;

namespace GoogleMusicApi.Requests
{
    public class MutatePlaylists : StructuredRequest<MutateRequest, MutateResponse>
    {
        public override string RelativeRequestUrl => "playlistbatch";
    }
}