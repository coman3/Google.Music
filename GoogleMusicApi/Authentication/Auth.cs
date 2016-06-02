using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace GoogleMusicApi.Authentication
{
    /// <summary>
    /// Provides methods for logging into the Google services.
    /// </summary>
    // gpsoauth:__init__.py
    // URL: https://github.com/simon-weber/gpsoauth/blob/master/gpsoauth/__init__.py
    public static class GoogleAuth
    {
        public const string UserAgent = "Android-Music/" + version;

        private const string authUrl = "https://android.clients.google.com/auth";

        private const string b64Key = "AAAAgMom/1a/v0lblO2Ubrt60J2gcuXSljGFQXgcyZWveWLEwo6prwgi3" +
                                      "iJIZdodyhKZQrNWp5nKJ3srRXcUW+F1BD3baEVGcmEgqaLZUNBjm057pK" +
                                      "RI16kB0YppeGx5qIQ5QjKzsR8ETQbKLNWgRY0QRNVz34kMJR3P/LgHax/" +
                                      "6rmf5AAAAAwEAAQ==";

        private const string version = "2817";

        private static readonly RSAParameters androidKey = GoogleKeyUtils.KeyFromB64(b64Key);

        private static readonly HttpClient httpClient;

        static GoogleAuth()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
        }

        public static string GetPcMacAddress()
        {
            return NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault()?.GetPhysicalAddress().ToString();
        }
        // perform_master_login
        public static async Task<Dictionary<string, string>> PerformMasterLoginAsync(UserDetails userDetails, LocaleDetails localeDetails,
            string service = "ac2dm", int sdkVersion = 17)
        {
            var signature = GoogleKeyUtils.CreateSignature(userDetails.Email, userDetails.Password, androidKey);

            var dict = new Dictionary<string, string>
            {
                {"accountType", "HOSTED_OR_GOOGLE"},
                {"Email", userDetails.Email},
                {"has_permission", "1"},
                {"add_account", "1"},
                {"EncryptedPasswd", signature},
                {"service", service},
                {"source", "android"},
                {"androidId", userDetails.AndroidId},
                {"device_country", localeDetails.DeviceCountry},
                {"operatorCountry", localeDetails.OperatorCountry},
                {"lang", localeDetails.Language},
                {"sdk_version", sdkVersion.ToString()}
            };

            return await performAuthRequestAsync(dict);
        }

        // perform_oauth
        public static async Task<Dictionary<string, string>> PerformOAuthAsync(UserDetails userDetails, LocaleDetails localeDetails,
            string masterToken, string service, string app, string clientSig, int sdkVersion = 21)
        {
            var dict = new Dictionary<string, string>
            {
                {"accountType", "HOSTED_OR_GOOGLE"},
                {"Email", userDetails.Email},
                {"has_permission", "1"},
                {"EncryptedPasswd", masterToken},
                {"service", service},
                {"source", "android"},
                {"app", app},
                {"client_sig", clientSig},
                {"device_country", localeDetails.DeviceCountry},
                {"operatorCountry", localeDetails.OperatorCountry},
                {"lang", localeDetails.Language},
                {"sdk_version", sdkVersion.ToString()}
            };

            return await performAuthRequestAsync(dict);
        }

        // _perform_auth_request
        private static async Task<Dictionary<string, string>> performAuthRequestAsync(Dictionary<string, string> data)
        {
            var content = new FormUrlEncodedContent(data);

            var response = await httpClient.PostAsync(authUrl, content);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return GoogleKeyUtils.ParseAuthResponse(result);
        }
    }
}