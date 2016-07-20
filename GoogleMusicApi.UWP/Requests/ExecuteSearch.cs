using GoogleMusicApi.UWP.Requests.Data;
using GoogleMusicApi.UWP.Structure;

namespace GoogleMusicApi.UWP.Requests
{
    public class ExecuteSearch : StructuredRequest<SearchGetRequest, SearchResponse>
    {
        public override string RelativeRequestUrl => "query";
    }
}