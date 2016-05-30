using System.Diagnostics.Eventing.Reader;
using System.Runtime.Serialization;

namespace GoogleMusicApi.Requests
{
    public class RecordRealTime : StructuredRequest<RecordRealTimeRequest, RecordRealTimeResponse>
    {
        public override string RelativeRequestUrl => "activity/recordreadltime";
        
    }
}