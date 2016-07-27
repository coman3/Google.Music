using GoogleMusicApi.UWP.Requests.Data;
using GoogleMusicApi.UWP.Structure;

namespace GoogleMusicApi.UWP.Requests
{
    public class GetTrack : StructuredRequest<GetTrackRequest, Track>
    {
        public override string RelativeRequestUrl => "fetchtrack";
    }
}