using System.Collections.Generic;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class GetTrack : StructuredRequest<GetTrackRequest, Track>
    {

        public override string RelativeRequestUrl => "fetchtrack";

        protected override ParsedRequest GetParsedRequest(GetTrackRequest request)
        {
            request.UrlData.Add(new KeyValuePair<string, string>("nid", request.TrackId));
            return base.GetParsedRequest(request);
        }
    }
}