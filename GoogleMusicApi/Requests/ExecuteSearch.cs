using System.Collections.Generic;
using System.Net;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ExecuteSearch : StructuredRequest<SearchGetRequest, SearchResponse>
    {
        public override string RelativeRequestUrl => "query";

    }
}