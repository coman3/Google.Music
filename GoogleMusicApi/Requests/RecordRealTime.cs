using GoogleMusicApi.Requests.Data;

namespace GoogleMusicApi.Requests
{
    public class RecordRealTime : StructuredRequest<RecordRealTimeRequest, RecordRealTimeResponse>
    {
        public override string RelativeRequestUrl => "activity/recordreadltime";
    }
}