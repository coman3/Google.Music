using System.Collections.Generic;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class GetTrack : StructuredRequest<GetTrackRequest, Track>
    {

        public override string RelativeRequestUrl => "fetchtrack";
    }
}