using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace GoogleMusicApi
{
    public abstract class Session
    {
        public string AuthorizationToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public abstract bool Login(string email, string password);

        public HttpClient HttpClient { get; set; }

        public async Task<bool> LoginAsync(string email, string password)
        {
            return await Task.Factory.StartNew(() => Login(email, password));
        }

        public abstract void ResetHeaders();
    }

    public sealed class MobileSession : Session
    {
        public string MasterToken { get; set; }

        public string AndroidId { get; set; }

        public override bool Login(string email, string password)
        {
            AndroidId = GetMacAddress();
            var oAuth = new GoogleAuth.GoogleAuth(email, password, AndroidId);
            var result = oAuth.PerformMasterLogin();

            if (!result.ContainsKey("Token")) return false;
            if (result.ContainsKey("firstName")) FirstName = result["firstName"];
            if (result.ContainsKey("lastName")) LastName = result["lastName"];
            if (result.ContainsKey("Email")) Email = result["Email"];
            MasterToken = result["Token"];
            result = oAuth.PerformOAuth(MasterToken, "sj", "com.google.android.music",
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
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(GoogleAuth.GoogleAuth.UserAgent);
            HttpClient.DefaultRequestHeaders.Add("X-Device-ID", AndroidId);

            return true;
        }

        public override void ResetHeaders()
        {
            if(HttpClient == null) return;
            HttpClient.DefaultRequestHeaders.Clear();

            HttpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("GoogleLogin auth=" + AuthorizationToken);
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(GoogleAuth.GoogleAuth.UserAgent);
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
}