namespace GoogleMusicApi.UWP.Authentication
{
    public sealed class LocaleDetails
    {
        public static readonly LocaleDetails Default = new LocaleDetails("us", "us", "en");

        public string DeviceCountry { get; }

        public string Language { get; }

        public string OperatorCountry { get; }

        public LocaleDetails(string deviceCountry, string operatorCountry, string language)
        {
            DeviceCountry = deviceCountry;
            OperatorCountry = operatorCountry;
            Language = language;
        }
    }
}