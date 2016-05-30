using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class StreamUrlGetRequest : GetRequest
    {
        private const string Key = "34ee7983-5ee6-4147-aa86-443ea062abf774493d6a-2a15-43fe-aace-e78566927585\n";
        public string Salt { get; set; }
        public Track Track { get; set; }
        public StreamQuality StreamQuality { get; set; }
        public bool OnWifi { get; set; }
        public StreamUrlGetRequest(MobileSession session, Track track, StreamQuality quality = StreamQuality.High, bool onWifi = true) : base(session)
        {
            Track = track;
            StreamQuality = quality;
            OnWifi = onWifi;
            UseCustomHeaders = true;
        }

        private static string GetQualityString(StreamQuality quality)
        {
            string qualtity;
            switch (quality)
            {
                case StreamQuality.Low:
                    qualtity = "low";
                    break;
                case StreamQuality.Medium:
                    qualtity = "nor";
                    break;
                case StreamQuality.High:
                    qualtity = "hi";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(quality), quality, null);
            }

            return qualtity;
        }

        private string GetSignature(Track track, string salt)
        {
            var songIdEncoded = Encoding.UTF8.GetBytes(track.StoreId);
            var hmac = new HMACSHA1(Encoding.ASCII.GetBytes(Key));
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

            return ((long) timeSpan).ToString(CultureInfo.InvariantCulture);
        }

        public override WebRequestHeaders GetUrlContent()
        {
            Salt = GetSalt();
            var signature = GetSignature(Track, Salt);
            UrlData.Clear();
            UrlData.Add(new WebRequestHeader(Track.StoreId.StartsWith("T") ? "mjck" : "songid", Track.StoreId));
            UrlData.Add(new WebRequestHeader("opt", GetQualityString(StreamQuality)));
            UrlData.Add(new WebRequestHeader("net", OnWifi ? "wifi" : "mob"));
            UrlData.Add(new WebRequestHeader("pt", "e")); //needed?
            UrlData.Add(new WebRequestHeader("p", "1")); //needed?
            UrlData.Add(new WebRequestHeader("slt", Salt));
            UrlData.Add(new WebRequestHeader("sig", signature));
            UrlData.Add(new WebRequestHeader("hl", Locale));
            UrlData.Add(new WebRequestHeader("tier", "aa"));
            return base.GetUrlContent();
        }

        public override void SetHeaders(HttpRequestHeaders headers)
        {
            headers.Accept.ParseAdd("*/*");
            headers.Authorization = AuthenticationHeaderValue.Parse("Bearer " + Session.AuthorizationToken);
            headers.UserAgent.ParseAdd(GoogleAuth.GoogleAuth.UserAgent);
            var mobile = Session as MobileSession;
            if(mobile != null)
                headers.Add("X-Device-ID", mobile.AndroidId);
        }
    }
}