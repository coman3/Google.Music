using GoogleMusicApi.UWP.Structure;

namespace GoogleMusicApi.UWP.Requests.Data
{
    public class GetRadioStationAnnotationResponse
    {
        public string Kind { get; set; }
        public StationAnnotation PrimaryStation { get; set; }
        public StationAnnotationRelatedGroup[] RelatedGroups { get; set; }
    }
}