using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;
using Newtonsoft.Json.Linq;

namespace GoogleMusicApi.Requests
{
    public class GetStationFeed : StructuredRequest<GetStationFeedRequest, RadioFeed>
    {
        public override string RelativeRequestUrl => "radio/stationfeed";
    }
}
