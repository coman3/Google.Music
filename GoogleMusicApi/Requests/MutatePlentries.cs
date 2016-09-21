using GoogleMusicApi.Requests.Data;

namespace GoogleMusicApi.Requests
{
    public class MutatePlentries : StructuredRequest<MutateRequest, MutateResponse>
    {
        public override string RelativeRequestUrl => "plentriesbatch";
    }
}