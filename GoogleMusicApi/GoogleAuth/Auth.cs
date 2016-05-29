using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace GoogleMusicApi.GoogleAuth
{
    // gpsoauth:__init__.py
    // URL: https://github.com/simon-weber/gpsoauth/blob/master/gpsoauth/__init__.py
    public class GoogleAuth
    {
        public const string Version = "2817";
        private const string AuthUrl = "https://android.clients.google.com/auth";
        public const string UserAgent = "Android-Music/" + Version;

        private static readonly string b64Key = "AAAAgMom/1a/v0lblO2Ubrt60J2gcuXSljGFQXgcyZWveWLEwo6prwgi3" +
                                                "iJIZdodyhKZQrNWp5nKJ3srRXcUW+F1BD3baEVGcmEgqaLZUNBjm057pK" +
                                                "RI16kB0YppeGx5qIQ5QjKzsR8ETQbKLNWgRY0QRNVz34kMJR3P/LgHax/" +
                                                "6rmf5AAAAAwEAAQ==";

        private static readonly RSAParameters AndroidKey = GoogleKeyUtils.KeyFromB64(b64Key);
        private readonly string _androidId;

        private readonly string _email;
        private readonly string _password;

        public GoogleAuth(string email, string password, string androidId)
        {
            _email = email;
            _password = password;
            _androidId = androidId;
        }

        // _perform_auth_request
        private Dictionary<string, string> PerformAuthRequest(Dictionary<string, string> data)
        {
            var nvc = new NameValueCollection();
            foreach (var kvp in data)
            {
                nvc.Add(kvp.Key, kvp.Value);
            }
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.UserAgent, UserAgent);
                string result;
                try
                {
                    var response = client.UploadValues(AuthUrl, nvc);
                    result = Encoding.UTF8.GetString(response);
                }
                catch (WebException e)
                {
                    if (e.Response == null) return new Dictionary<string, string>(0);
                    var stream = e.Response.GetResponseStream();
                    if (stream == null) return new Dictionary<string, string>(0);
                    result = new StreamReader(stream).ReadToEnd();
                }
                return GoogleKeyUtils.ParseAuthResponse(result);
            }
        }

        // perform_master_login
        public Dictionary<string, string> PerformMasterLogin(string service = "ac2dm",
            string deviceCountry = "us", string operatorCountry = "us", string lang = "en", int sdkVersion = 17)
        {
            var signature = GoogleKeyUtils.CreateSignature(_email, _password, AndroidKey);
            var dict = new Dictionary<string, string>
            {
                {"accountType", "HOSTED_OR_GOOGLE"},
                {"Email", _email},
                {"has_permission", 1.ToString()},
                {"add_account", 1.ToString()},
                {"EncryptedPasswd", signature},
                {"service", service},
                {"source", "android"},
                {"androidId", _androidId},
                {"device_country", deviceCountry},
                {"operatorCountry", operatorCountry},
                {"lang", lang},
                {"sdk_version", sdkVersion.ToString()}
            };
            return PerformAuthRequest(dict);
        }

        // perform_oauth
        public Dictionary<string, string> PerformOAuth(string masterToken, string service, string app, string clientSig,
            string deviceCountry = "us", string operatorCountry = "us", string lang = "en", int sdkVersion = 21)
        {
            var dict = new Dictionary<string, string>
            {
                {"accountType", "HOSTED_OR_GOOGLE"},
                {"Email", _email},
                {"has_permission", 1.ToString()},
                {"EncryptedPasswd", masterToken},
                {"service", service},
                {"source", "android"},
                {"app", app},
                {"client_sig", clientSig},
                {"device_country", deviceCountry},
                {"operatorCountry", operatorCountry},
                {"lang", lang},
                {"sdk_version", sdkVersion.ToString()}
            };
            return PerformAuthRequest(dict);
        }
    }
}