using GoogleMusicApi.UWP.Requests.Data;

namespace GoogleMusicApi.UWP.Requests
{
    //TODO (Low): Get Working
    public class EditRadioStation : StructuredRequest<EditRadioStationRequest, EditRadioStationReponse>
    {
        public override string RelativeRequestUrl => "radio/editstation";
    }
}