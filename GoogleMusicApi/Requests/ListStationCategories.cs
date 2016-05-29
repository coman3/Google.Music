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
            request.UrlData.Add(new WebRequestHeader("alt", "json"));
            request.UrlData.Add(new WebRequestHeader("hl", "en_AU"));
            return base.GetParsedRequest(request);
        }
    }
}