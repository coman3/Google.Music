using GoogleMusicApi.Sessions;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class GetStaionFeed : StructuredRequest<GetStaionFeedRequest, GetStaionFeedResponse>
    {
        public override string RelativeRequestUrl => "radio/stationfeed";
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetStaionFeedRequest : PostRequest
    {
        [JsonProperty("contentFilter")]
        public int ContentFilter { get; set; }

        public RequestType RequestKind { get; set; }

        [JsonProperty("stations")]
        public StationFeed[] Stations { get; set; }

        public GetStaionFeedRequest(Session session) : base(session)
        {
        }

        public override WebRequestHeaders GetUrlContent()
        {
            UrlData.Add(new WebRequestHeader("rz", RequestKind == RequestType.Start ? "start" : "ext"));
            return base.GetUrlContent();
        }

        public enum RequestType
        {
            Start, //start
            Extention //ext
        }
    }

    public class GetStaionFeedResponse
    {
    }

    public class StationFeed
    {
        [JsonProperty("libraryContentOnly")]
        public bool LibraryContentOnly { get; set; }

        [JsonProperty("numEntries")]
        public int NumberOfEntries { get; set; }

        [JsonProperty("radioId")]
        public string RadioId { get; set; }

        /// <summary>
        /// Which songs have played recently, so google does not suggest them again.
        /// </summary>
        [JsonProperty("recentlyPlayed")]
        public StationFeedRecentTrack[] RecentlyPlayed { get; set; }
    }

    public class StationFeedRecentTrack
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }
}