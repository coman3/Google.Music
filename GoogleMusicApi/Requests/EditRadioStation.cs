namespace GoogleMusicApi.Requests
{
    //TODO (High): Get Working
    public class EditRadioStation : StructuredRequest<EditRadioStationRequest, EditRadioStationReponse>
    {
        public override string RelativeRequestUrl => "radio/editstation";
    }
}