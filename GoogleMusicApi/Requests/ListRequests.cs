using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Text;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class ListPlaylists : StructuredRequest<ResultListRequest, ResultList<Playlist>>
    {
        public override string RelativeRequestUrl => "playlistfeed";
    }
    public class ListPlaylistEntries : StructuredRequest<ResultListRequest, ResultList<Plentry>>
    {
        public override string RelativeRequestUrl => "plentryfeed";
    }
    public class ListTrackFeed : StructuredRequest<ResultListRequest, ResultList<Track>>
    {
        public override string RelativeRequestUrl => "trackfeed";
    }
    public class ListPromotedTracks : StructuredRequest<ResultListRequest, ResultList<Track>>
    {
        public override string RelativeRequestUrl => "ephemeral/top";
    }

    public class ListListenNowTracks : StructuredRequest<GetRequest, ListListenNowTracksResponse>
    {
        public override string RelativeRequestUrl => "listennow/getlistennowitems";
    }

    public class ListListenNowSituations :
        StructuredRequest<ListListenNowSituationsRequest, ListListenNowSituationResponse>
    {
        public override string RelativeRequestUrl => "listennow/situations";
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListListenNowSituationsRequest : PostRequest
    {
        [JsonProperty("requestSignals")]
        public RequestSignal RequestSignals { get; set; }

        [JsonProperty("situationType")]
        public int[] SituationType { get; set; }

        [JsonObject]
        public class RequestSignal
        {
            [JsonProperty("timeZoneOffsetSecs")]
            public int TimeZoneOffsetSecs { get; set; }
        }

        public ListListenNowSituationsRequest(Session session) : base(session)
        {
            UrlData.Add(new KeyValuePair<string, string>("alt", "json"));
            UrlData.Add(new KeyValuePair<string, string>("hl", "en_AU"));
            Headers.Add(new KeyValuePair<string, string>("X-Device-ID", ((MobileSession)session).AndroidId));
        }

        public override byte[] GetRequestBody()
        {
            SituationType = new[] {1};
            RequestSignals = new RequestSignal();
            RequestSignals.TimeZoneOffsetSecs = (int)(DateTime.Now - DateTime.UtcNow).TotalSeconds;
            var json = JsonConvert.SerializeObject(this);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}