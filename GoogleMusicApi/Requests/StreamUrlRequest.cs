using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class StreamUrlRequest : StructuredRequest<StreamUrlGetRequest, string>
    {
        
        public override string RelativeRequestUrl => "music/mplay";

        public override string Get(StreamUrlGetRequest data)
        {
            var request = GetParsedRequest(data);
            var webRequest = request.GetWebRequest();
            webRequest.AllowAutoRedirect = false;
            var response = webRequest.GetResponse();

            // ReSharper disable once AssignNullToNotNullAttribute
            if (response.Headers.Get("location") != null)
            {
                return response.Headers.Get("location");
            }
            return null;
        }

        public override string GetRequestUrl(Request request)
        {
            return "https://android.clients.google.com/music/mplay" + GetParams(request);
        }
    }

    public class StreamUrlGetRequest : GetRequest
    {
        private string _key = "34ee7983-5ee6-4147-aa86-443ea062abf774493d6a-2a15-43fe-aace-e78566927585\n";
        public string Salt { get; set; }
        public Track Track { get; set; }
        public StreamUrlGetRequest(MobileSession session, Track track) : base(session)
        {
            Accept = "*/*";
            Track = track;
            Salt = GetSalt();
            var signature = GetSignature(track, Salt);

            UrlData = new WebRequestHeaders
            {
                new KeyValuePair<string, string>(track.StoreId.StartsWith("T") ? "mjck" : "songid", track.StoreId),
                //new KeyValuePair<string, string>("targetkbps", "63373"),
                //new KeyValuePair<string, string>("audio_formats", "mp3"),
                //new KeyValuePair<string, string>("dv", "2817"),//needed?
                //new KeyValuePair<string, string>("p", "1"),//needed?
                new KeyValuePair<string, string>("opt", "hi"),
                new KeyValuePair<string, string>("net", "mob"),
                new KeyValuePair<string, string>("pt", "e"),//needed?
                new KeyValuePair<string, string>("slt", Salt),
                new KeyValuePair<string, string>("sig", signature),
                new KeyValuePair<string, string>("tier", "aa"),

            };
            Headers = new WebRequestHeaders
            {
                new KeyValuePair<string, string>("X-Device-ID", session.AndroidId),
            };
        }

        private string GetSignature(Track track, string salt)
        {
            var songIdEncoded = Encoding.UTF8.GetBytes(track.StoreId);
            var hmac = new HMACSHA1(Encoding.ASCII.GetBytes(_key));
            var saltEncoded = Encoding.UTF8.GetBytes(salt);
            byte[] data;
            using (var ms = new MemoryStream())
            {
                ms.Write(songIdEncoded, 0, songIdEncoded.Length);
                ms.Write(saltEncoded, 0, saltEncoded.Length);
                data = ms.ToArray();
            }
            var sig = Convert.ToBase64String(hmac.ComputeHash(data, 0, data.Length));
            sig = sig.Replace('+', '-').Replace('/', '_').Replace("=", "");
            return sig;
        }
        private string GetSalt()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds*1000;
            
            return ((long)(timeSpan)).ToString(CultureInfo.InvariantCulture);

        }
    }
}