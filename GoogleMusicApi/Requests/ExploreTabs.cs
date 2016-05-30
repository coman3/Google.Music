using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class ExploreTabs : StructuredRequest<ExploreTabsRequest, ExploreTabsResponse>
    {
        public override string RelativeRequestUrl => "explore/tabs";
    }

    //TODO (Low): Split Into Separate Files
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
        public EntityGroup[] Groups { get; set; }



    }

    public class EntityGroup
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("entities")]
        public Entity[] Entities { get; set; }

        [JsonProperty("group_type")]
        public string GroupType { get; set; }

        [JsonProperty("continuation_token")]
        public string ContinuationToken { get; set; }

        [JsonProperty("start_position")]
        public int StartPosition { get; set; }


    }

    public class Entity
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
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
        }

        public override WebRequestHeaders GetUrlContent()
        {
            UrlData.Add(new WebRequestHeader("num-items", NumberOfItems.ToString()));
            UrlData.Add(new WebRequestHeader("tabs", Tabs.ToString()));
            return base.GetUrlContent();
        }
    }
}