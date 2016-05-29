using System;
using System.Collections.Generic;

namespace GoogleMusicApi
{
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

    public class WebRequestHeader
    {
        private KeyValuePair<string, string> Pair { get; }

        public string Key => Pair.Key;
        public string Value => Pair.Value;

        public WebRequestHeader(string key, string value)
        {
            Pair = new KeyValuePair<string, string>(key, value);
        }

        public static explicit operator KeyValuePair<string, string>(WebRequestHeader header)
        {
            return header.Pair;
        }
    }
}