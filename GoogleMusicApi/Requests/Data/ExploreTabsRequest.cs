using System;
using GoogleMusicApi.Common;
using GoogleMusicApi.Sessions;
using GoogleMusicApi.Structure;
using GoogleMusicApi.Structure.Enums;

namespace GoogleMusicApi.Requests.Data
{
    public class ExploreTabsRequest : GetRequest
    {
        /// <summary>
        /// Tab: 2 = NEW_RELEASES
        /// </summary>
        public int Tabs { get; set; } //TODO (High): Find out what tabs there are, and set this to an enum
        public TabGenre Genre { get; set; }
        public int NumberOfItems { get; set; }
        public ExploreTabsRequest(Session session) : base(session)
        {
        }

        public override WebRequestHeaders GetUrlContent()
        {
            UrlData.Add(new WebRequestHeader("num-items", NumberOfItems.ToString()));
            UrlData.Add(new WebRequestHeader("tabs", Tabs.ToString()));
            UrlData.Add(new WebRequestHeader("genre", Enumerations.GetDataName(Genre)));
            return base.GetUrlContent();
        }
    }
}
