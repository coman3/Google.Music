using System.Collections.Generic;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ListStationCategories :
        StructuredRequest<GetRequest, ListStationCategoriesResponse>
    {
        public override string RelativeRequestUrl => "browse/stationcatergories";

        public override string GetRequestUrl(Request request)
        {
            request.UrlData = new WebRequestHeaders
            {
                new KeyValuePair<string, string>("alt", "json"),
                new KeyValuePair<string, string>("hl", "en_AU")
            };
            return base.GetRequestUrl(request);
        }
    }
}