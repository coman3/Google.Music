using GoogleMusicApi.Authentication;
using GoogleMusicApi.Sessions;
using GoogleMusicApi.Structure;
using PCLCrypto;
using System;
using System.Globalization;
using System.Text;

namespace GoogleMusicApi.Requests.Data
{
    public class StreamUrlGetRequest : GetRequest
    {
        private const string Key = "34ee7983-5ee6-4147-aa86-443ea062abf774493d6a-2a15-43fe-aace-e78566927585\n";
        public bool OnWifi { get; set; }
        public string Salt { get; set; }
        public StreamQuality StreamQuality { get; set; }
        public Track Track { get; set; }

        public StreamUrlGetRequest(MobileSession session, Track track, StreamQuality quality = StreamQuality.High, bool onWifi = true) : base(session)
        {
            Track = track;
            StreamQuality = quality;
            OnWifi = onWifi;
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

        private string GetSalt()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds * 1000;

            return ((long)timeSpan).ToString(CultureInfo.InvariantCulture);
        }

        private string GetSignature(Track track, string salt)
        {
            // https://en.wikipedia.org/wiki/Hash-based_message_authentication_code
            throw new NotImplementedException("Implement HMAC-SHA1!");

            var songIdEncoded = Encoding.UTF8.GetBytes(track.StoreId);
            var saltEncoded = Encoding.UTF8.GetBytes(salt);
            var hmacKey = Encoding.UTF8.GetBytes(Key);

            var data = DataTypeUtils.CombineBytes(songIdEncoded, saltEncoded);

            var hmac = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);

            var sig = DataTypeUtils.ToUrlSafeBase64(hmac.HashData(data));

            return sig;
        }
    }
}