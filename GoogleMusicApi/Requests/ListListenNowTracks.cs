using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ListListenNowTracks : StructuredRequest<GetRequest, ListListenNowTracksResponse>
    {
        public override string RelativeRequestUrl => "listennow/getlistennowitems";
    }
}