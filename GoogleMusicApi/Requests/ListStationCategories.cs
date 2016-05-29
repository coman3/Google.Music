using System.Collections.Generic;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ListStationCategories :
        StructuredRequest<GetRequest, ListStationCategoriesResponse>
    {
        public override string RelativeRequestUrl => "browse/stationcatergories";

        protected override ParsedRequest GetParsedRequest(GetRequest request)
        {
            request.UrlData.Add(new KeyValuePair<string, string>("alt", "json"));
            request.UrlData.Add(new KeyValuePair<string, string>("hl", "en_AU"));
            return base.GetParsedRequest(request);
        }
    }
}