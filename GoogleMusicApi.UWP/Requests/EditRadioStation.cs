using GoogleMusicApi.Requests.Data;

namespace GoogleMusicApi.Requests
{
    //TODO (Low): Get Working
    public class EditRadioStation : StructuredRequest<EditRadioStationRequest, EditRadioStationReponse>
    {
        public override string RelativeRequestUrl => "radio/editstation";
    }
}