using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class ExploreTabs : StructuredRequest<ExploreTabsRequest, ExploreTabsResponse>
    {
        public override string RelativeRequestUrl => "explore/tabs";
        protected override ParsedRequest GetParsedRequest(ExploreTabsRequest request)
        {
            request.UrlData.Add(new WebRequestHeader("num-items", request.NumberOfItems.ToString()));
            request.UrlData.Add(new WebRequestHeader("tabs", request.Tabs.ToString()));
            return base.GetParsedRequest(request);
        }
    }

    public class ExploreTabsResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("tabs")]
        public ExploreTab[] Tabs { get; set; }
    }

    public class ExploreTab
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("tab_type")]
        public string TabType { get; set; }

        [JsonProperty("groups")]
        public EntityGroup[] EntityGroups { get; set; }



    }

    public class EntityGroup
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("entities")]
        public Entity[] Entities { get; set; }


    }

    public class Entity
    {
        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("explicitType")]
        public int ExplicitType { get; set; }

    }

    public class ExploreTabsRequest : GetRequest
    {
        /// <summary>
        /// Tab: 2 = NEW_RELEASES
        /// </summary>
        public int Tabs { get; set; } //TODO (High): Find out what tabs there are, and set this to an enum
        public int NumberOfItems { get; set; }
        public ExploreTabsRequest(Session session) : base(session)
        {
            UrlData.Add(new WebRequestHeader("alt", "json"));
            UrlData.Add(new WebRequestHeader("hl", "en_AU"));
            
        }
    }
}