using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        public StreamUrlGetRequest(MobileSession session, Track track, StreamQuality quality = StreamQuality.High, bool onWifi = true) : base(session)
        {
            Accept = "*/*";
            Track = track;
            Salt = GetSalt();
            var signature = GetSignature(track, Salt);

            UrlData.Add(new WebRequestHeader(track.StoreId.StartsWith("T") ? "mjck" : "songid", track.StoreId));
            UrlData.Add(new WebRequestHeader("opt", GetQualityString(quality)));
            UrlData.Add(new WebRequestHeader("net", onWifi ? "net" : "mob"));
            UrlData.Add(new WebRequestHeader("pt", "e")); //needed?
            UrlData.Add(new WebRequestHeader("slt", Salt));
            UrlData.Add(new WebRequestHeader("sig", signature));
            UrlData.Add(new WebRequestHeader("tier", "aa"));
            Headers = new WebRequestHeaders
            {
                new WebRequestHeader("X-Device-ID", session.AndroidId)
            };
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
    }
}