using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;
using System.Collections.Generic;

namespace GoogleMusicApi.Requests
{
    public class ExecuteSearch : StructuredRequest<SearchGetRequest, SearchResponse>
    {
        public override string RelativeRequestUrl => "query";
    }
}