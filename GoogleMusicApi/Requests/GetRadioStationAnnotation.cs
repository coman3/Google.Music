using GoogleMusicApi.Requests.Data;

namespace GoogleMusicApi.Requests
{
    public class GetRadioStationAnnotation :
        StructuredRequest<GetRadioStationAnnotationRequest, GetRadioStationAnnotationResponse>
    {
        public override string RelativeRequestUrl => "fetchradiostationannotation";
    }
}