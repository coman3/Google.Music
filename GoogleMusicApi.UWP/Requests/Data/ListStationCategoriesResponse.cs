using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    public class ListStationCategoriesResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("root")]
        public StationCategory Root { get; set; }
    }

    public class StationCategory
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("subcategories")]
        public StationCategory[] SubCategories { get; set; }
    }
}