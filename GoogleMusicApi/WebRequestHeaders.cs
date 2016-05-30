using System;
using System.Collections.Generic;

namespace GoogleMusicApi
{
    public class WebRequestHeader
    {
        public string Key => Pair.Key;
        public string Value => Pair.Value;
        private KeyValuePair<string, string> Pair { get; }

        public WebRequestHeader(string key, string value)
        {
            Pair = new KeyValuePair<string, string>(key, value);
        }

        public static explicit operator KeyValuePair<string, string>(WebRequestHeader header)
        {
            return header.Pair;
        }
    }

    public class WebRequestHeaders : List<WebRequestHeader>
    {
        public WebRequestHeaders()
        {
        }

        public WebRequestHeaders(params WebRequestHeader[] headers)
        {
            AddRange(headers);
        }
    }
}