using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;
using System.Collections.Generic;

namespace GoogleMusicApi.Requests
{
    public class GetTrack : StructuredRequest<GetTrackRequest, Track>
    {
        public override string RelativeRequestUrl => "fetchtrack";
    }
}