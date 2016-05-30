using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ListPromotedTracks : StructuredRequest<ResultListRequest, ResultList<Track>>
    {
        public override string RelativeRequestUrl => "ephemeral/top";
    }
}