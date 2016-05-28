using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class GetRadioStationAnnotationResponse
    {
        public string Kind { get; set; }
        public StationAnnotation PrimaryStation { get; set; }
        public StationAnnotationRelatedGroup[] RelatedGroups { get; set; }
    }
}