using System.Collections.Generic;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ListStationCategories :
        StructuredRequest<GetRequest, ListStationCategoriesResponse>
    {
        public override string RelativeRequestUrl => "browse/stationcatergories";

    }
}