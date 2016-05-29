namespace GoogleMusicApi.Requests
{
    public class RadioStationAnnotation :
        StructuredRequest<GetRadioStationAnnotationRequest, GetRadioStationAnnotationResponse>
    {
        public override string RelativeRequestUrl => "fetchradiostationannotation";
    }
}