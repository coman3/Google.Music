using GoogleMusicApi.Requests.Data;

namespace GoogleMusicApi.Requests
{
    public class ListStationCategories :
        StructuredRequest<GetRequest, ListStationCategoriesResponse>
    {
        public override string RelativeRequestUrl => "browse/stationcategories";
    }
}