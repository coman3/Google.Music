using GoogleMusicApi.UWP.Requests.Data;

namespace GoogleMusicApi.UWP.Requests
{
    public class MutatePlentries : StructuredRequest<MutateRequest, MutateResponse>
    {
        public override string RelativeRequestUrl => "plentriesbatch";
    }
}