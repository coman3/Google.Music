using GoogleMusicApi.UWP.Requests.Data;

namespace GoogleMusicApi.UWP.Requests
{
    public class ListListenNowTracks : StructuredRequest<GetRequest, ListListenNowTracksResponse>
    {
        public override string RelativeRequestUrl => "listennow/getlistennowitems";
    }
}