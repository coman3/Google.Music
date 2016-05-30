using GoogleMusicApi.Requests.Data;
using System.Collections.Generic;

namespace GoogleMusicApi.Requests
{
    public class ListStationCategories :
        StructuredRequest<GetRequest, ListStationCategoriesResponse>
    {
        public override string RelativeRequestUrl => "browse/stationcategories";
    }
}