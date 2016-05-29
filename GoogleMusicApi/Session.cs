using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using GoogleMusicApi.GoogleAuth;

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

        public async Task<bool> LoginAsync(string email, string password)
        {
            return await Task.Factory.StartNew(() => Login(email, password));
        }
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

            return true;
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
