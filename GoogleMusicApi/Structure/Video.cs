using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Video
    {
        // "id": "YXIHXQjbtl8",
        [JsonProperty("id")]
        public string Id { get; set; }

        //"primaryVideo": {
        // "kind": "sj#video",
        [JsonProperty("kind")]
        public string Kind { get; set; }

        // "thumbnails": [
        //  {
        //   "url": "https://i.ytimg.com/vi/YXIHXQjbtl8/mqdefault.jpg",
        //   "width": 320,
        //   "height": 180
        //  }
        // ]
        [JsonProperty("thumbnails")]
        public List<Image> Thumbnails { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        //}
    }
}