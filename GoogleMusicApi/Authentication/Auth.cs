using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using GoogleMusicApi.Common;

namespace GoogleMusicApi.Authentication
{
    /// <summary>
    /// Provides methods for logging into the Google services.
    /// </summary>
    // gpsoauth:__init__.py
    // URL: https://github.com/simon-weber/gpsoauth/blob/master/gpsoauth/__init__.py
    public static class GoogleAuth
    {
        public const string UserAgent = "Android-Music/" + Version;

        private const string AuthUrl = "https://android.clients.google.com/auth";

        private const string B64Key = "AAAAgMom/1a/v0lblO2Ubrt60J2gcuXSljGFQXgcyZWveWLEwo6prwgi3" +
                                      "iJIZdodyhKZQrNWp5nKJ3srRXcUW+F1BD3baEVGcmEgqaLZUNBjm057pK" +
                                      "RI16kB0YppeGx5qIQ5QjKzsR8ETQbKLNWgRY0QRNVz34kMJR3P/LgHax/" +
                                      "6rmf5AAAAAwEAAQ==";

        private const string Version = "3120";

        private static readonly RSAParameters AndroidKey = GoogleKeyUtils.KeyFromB64(B64Key);

        private static readonly HttpClient HttpClient;

        static GoogleAuth()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
        }

        public static string GetDeviceId()
        {
            //CAN NOT BE LONGER THAN 16 CHARS. (i sware i didnt spent like 13 hours finding out why this wasnt working........)
            return DeviceInfo.CalculateMd5Hash(DeviceInfo.Instance.Id).Substring(0, 15);
        }
        // perform_master_login
        public static async Task<Dictionary<string, string>> PerformMasterLoginAsync(UserDetails userDetails, LocaleDetails localeDetails,
            string service = "ac2dm", int sdkVersion = 17)
        {
            var signature = GoogleKeyUtils.CreateSignature(userDetails.Email, userDetails.Password, AndroidKey);

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

            return await PerformAuthRequestAsync(dict);
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

            return await PerformAuthRequestAsync(dict);
        }

        // _perform_auth_request
        private static async Task<Dictionary<string, string>> PerformAuthRequestAsync(Dictionary<string, string> data)
        {
            var content = new FormUrlEncodedContent(data);

            var response = await HttpClient.PostAsync(AuthUrl, content);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return GoogleKeyUtils.ParseAuthResponse(result);
        }
    }
}