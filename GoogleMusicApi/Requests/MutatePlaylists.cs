using GoogleMusicApi.Requests.Data;

namespace GoogleMusicApi.Requests
{
    public class MutatePlaylists : StructuredRequest<MutatePlaylistsRequest, MutatePlaylistsResponse>
    {
        public override string RelativeRequestUrl => "playlistbatch";
    }
}