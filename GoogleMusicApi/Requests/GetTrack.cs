using System.Collections.Generic;
using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class GetTrack : StructuredRequest<GetTrackRequest, Track>
    {

        public override string RelativeRequestUrl => "fetchtrack";
    }
}