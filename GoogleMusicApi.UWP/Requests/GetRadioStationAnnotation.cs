using GoogleMusicApi.UWP.Requests.Data;

namespace GoogleMusicApi.UWP.Requests
{
    public class GetRadioStationAnnotation :
        StructuredRequest<GetRadioStationAnnotationRequest, GetRadioStationAnnotationResponse>
    {
        public override string RelativeRequestUrl => "fetchradiostationannotation";
    }
}