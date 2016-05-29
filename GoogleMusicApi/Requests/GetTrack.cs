using System.Collections.Generic;
using System.IO;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class GetTrack : StructuredRequest<GetTrackRequest, Track>
    {
        public override string RelativeRequestUrl => "fetchtrack";
        public GetTrack(string trackId)
        {
        }
        
        protected override ParsedRequest GetParsedRequest(GetTrackRequest request)
        {
            request.UrlData.Add(new KeyValuePair<string, string>("nid", request.TrackId));
            return base.GetParsedRequest(request);
        }
    }
}