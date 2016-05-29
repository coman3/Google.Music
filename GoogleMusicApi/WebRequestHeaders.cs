using System.Collections.Generic;

namespace GoogleMusicApi
{
    public class WebRequestHeaders : List<KeyValuePair<string, string>>
    {
        public WebRequestHeaders()
        {
        }

        public WebRequestHeaders(params KeyValuePair<string, string>[] headers)
        {
            AddRange(headers);
        }
    }
}