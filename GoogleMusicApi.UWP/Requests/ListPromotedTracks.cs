using GoogleMusicApi.UWP.Requests.Data;
using GoogleMusicApi.UWP.Structure;

namespace GoogleMusicApi.UWP.Requests
{
    public class ListPromotedTracks : StructuredRequest<ResultListRequest, ResultList<Track>>
    {
        public override string RelativeRequestUrl => "ephemeral/top";
    }
}