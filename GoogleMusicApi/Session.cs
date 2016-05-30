using GoogleMusicApi.Authentication;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace GoogleMusicApi
{
    public sealed class MobileSession : Session
    {
        public string AndroidId { get; set; }
        public string MasterToken { get; set; }

        public override async Task<bool> LoginAsync(string email, string password)
        {
            AndroidId = GetMacAddress();
            var userDetails = new UserDetails(email, password, AndroidId);
            var result = await GoogleAuth.PerformMasterLoginAsync(userDetails, LocaleDetails.Default);

            if (!result.ContainsKey("Token")) return false;
            if (result.ContainsKey("firstName")) FirstName = result["firstName"];
            if (result.ContainsKey("lastName")) LastName = result["lastName"];
            if (result.ContainsKey("Email")) Email = result["Email"];
            MasterToken = result["Token"];
            result = await GoogleAuth.PerformOAuthAsync(userDetails, LocaleDetails.Default, MasterToken, "sj", "com.google.android.music",
                "38918a453d07199354f8b19af05ec6562ced5788"); //Login to google play music

            if (!result.ContainsKey("Auth")) return false;
            AuthorizationToken = result["Auth"];
            IsAuthenticated = true; //Finished Auth

            HttpClient = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = false
            })
            {
                BaseAddress = new Uri(StructuredRequest.BaseApiUrl)
            };
            HttpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpClient.DefaultRequestHeaders.Authorization =
                AuthenticationHeaderValue.Parse("GoogleLogin auth=" + AuthorizationToken);
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(Authentication.GoogleAuth.UserAgent);
            HttpClient.DefaultRequestHeaders.Add("X-Device-ID", AndroidId);

            return true;
        }

        public override void ResetHeaders()
        {
            if (HttpClient == null) return;
            HttpClient.DefaultRequestHeaders.Clear();

            HttpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("GoogleLogin auth=" + AuthorizationToken);
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(Authentication.GoogleAuth.UserAgent);
            HttpClient.DefaultRequestHeaders.Add("X-Device-ID", AndroidId);
        }

        private static string GetMacAddress()
        {
            return
                NetworkInterface.GetAllNetworkInterfaces()
                    .Where(nic => nic.OperationalStatus == OperationalStatus.Up)
                    .Select(nic => nic.GetPhysicalAddress().ToString())
                    .FirstOrDefault();
        }
    }

    public abstract class Session
    {
        public string AuthorizationToken { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public HttpClient HttpClient { get; set; }
        public bool IsAuthenticated { get; set; }
        public string LastName { get; set; }

        public abstract bool LoginAsync(string email, string password);

        public async Task<bool> LoginAsync(string email, string password)
        {
            return await Task.Factory.StartNew(() => LoginAsync(email, password));
        }

        public abstract void ResetHeaders();
    }
}