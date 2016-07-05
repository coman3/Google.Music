using System;
using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Sessions;
using GoogleMusicApi.Structure.Mutations;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class MutatePlentries : StructuredRequest<MutateRequest, MutateResponse>
    {
        public override string RelativeRequestUrl => "plentriesbatch";
    }
}