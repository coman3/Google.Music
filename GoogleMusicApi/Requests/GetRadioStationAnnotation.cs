using Newtonsoft.Json.Serialization;

namespace GoogleMusicApi.Requests
{
    public class GetRadioStationAnnotation : StructuredRequest<GetRadioStationAnnotationRequest, GetRadioStationAnnotationResponse>
    {
        public override string RelativeRequestUrl => "fetchradiostationannotation";
    }
}