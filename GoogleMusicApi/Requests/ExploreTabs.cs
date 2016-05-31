using GoogleMusicApi.Sessions;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class Entity
    {
        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("explicitType")]
        public int ExplicitType { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }
    }

    public class EntityGroup
    {
        [JsonProperty("continuation_token")]
        public string ContinuationToken { get; set; }

        [JsonProperty("entities")]
        public Entity[] Entities { get; set; }

        [JsonProperty("group_type")]
        public string GroupType { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("start_position")]
        public int StartPosition { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class ExploreTab
    {
        [JsonProperty("groups")]
        public EntityGroup[] Groups { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("tab_type")]
        public string TabType { get; set; }
    }

    public class ExploreTabs : StructuredRequest<ExploreTabsRequest, ExploreTabsResponse>
    {
        public override string RelativeRequestUrl => "explore/tabs";
    }

    public class ExploreTabsRequest : GetRequest
    {
        public int NumberOfItems { get; set; }

        /// <summary>
        /// Tab: 2 = NEW_RELEASES
        /// </summary>
        public int Tabs { get; set; } //TODO (High): Find out what tabs there are, and set this to an enum

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

    //TODO (Low): Split Into Separate Files
    public class ExploreTabsResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("tabs")]
        public ExploreTab[] Tabs { get; set; }
    }
}