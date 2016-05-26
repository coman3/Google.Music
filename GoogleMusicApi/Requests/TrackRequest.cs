using System.Collections.Generic;
using System.IO;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class TrackRequest : StructuredRequest<GetRequest, Track>
    {
        public string TrackId { get; set; }
        public TrackRequest(string trackId)
        {
            TrackId = trackId;
        }
        public override string RelativeRequestUrl => "fetchtrack";
        public override string GetRequestUrl(Request request)
        {
            request.UrlData = new WebRequestHeaders
            {
                 new KeyValuePair<string, string>("nid", TrackId)
            };
            return base.GetRequestUrl(request);
        }
    }
}