using GoogleMusicApi.UWP.Requests.Data;

namespace GoogleMusicApi.UWP.Requests
{
    public class RecordRealTime : StructuredRequest<RecordRealTimeRequest, RecordRealTimeResponse>
    {
        public override string RelativeRequestUrl => "activity/recordrealtime";
    }
}