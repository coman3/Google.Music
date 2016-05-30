using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ListPlaylistEntries : StructuredRequest<ResultListRequest, ResultList<Plentry>>
    {
        public override string RelativeRequestUrl => "plentryfeed";
    }
}