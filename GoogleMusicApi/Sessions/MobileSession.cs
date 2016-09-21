using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GoogleMusicApi.Authentication;

namespace GoogleMusicApi.Sessions
{
    public sealed class MobileSession : Session
    {
        public string MasterToken { get; private set; }

        public UserDetails UserDetails { get; }

        public MobileSession(UserDetails userDetails)
        {
            UserDetails = userDetails;
        }

        public override async Task<bool> LoginAsync()
        {
            var result = await GoogleAuth.PerformMasterLoginAsync(UserDetails, LocaleDetails.Default);

            if (!result.ContainsKey("Token"))
                return false;

            if (result.ContainsKey("firstName"))
                FirstName = result["firstName"];

            if (result.ContainsKey("lastName"))
                LastName = result["lastName"];

            MasterToken = result["Token"];
            UserDetails.ClearPassword();

            return await LoginAsync(MasterToken);
        }

        public override async Task<bool> LoginAsync(string masterToken)
        {
            var result = await GoogleAuth.PerformOAuthAsync(UserDetails, 
                LocaleDetails.Default, masterToken, "sj", "com.google.android.music",
                "38918a453d07199354f8b19af05ec6562ced5788"); //Login to google play music

            if (!result.ContainsKey("Auth"))
                return false;

            AuthorizationToken = result["Auth"];
            IsAuthenticated = true; //Finished Auth

            HttpClient = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = false
            })
            {
                BaseAddress = new Uri(StructuredRequest.BaseApiUrl)
            };

            ResetHeaders();

            return true;
        }

        public override void ResetHeaders()
        {
            if (HttpClient == null)
                return;

            HttpClient.DefaultRequestHeaders.Clear();

            HttpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(GoogleAuth.UserAgent);
            HttpClient.DefaultRequestHeaders.Add("X-Device-ID", UserDetails.AndroidId);
            HttpClient.DefaultRequestHeaders.Add("X-Device-Logging-ID", "ID" + UserDetails.AndroidId);
            HttpClient.DefaultRequestHeaders.Authorization =
                AuthenticationHeaderValue.Parse("GoogleLogin auth=" + AuthorizationToken);
        }
    }
}