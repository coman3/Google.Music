using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class SearchResult
    {

        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("best_result")]
        public bool BestResult { get; set; }

        [JsonProperty("navigational_result")]
        public bool NavigationalResult { get; set; }

        [JsonProperty("navigational_confidence")]
        public int NavigationalConfidence { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }

        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("track")]
        public Track Track { get; set; }

        [JsonProperty("playlist")]
        public Playlist Playlist { get; set; }

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("situation")]
        public Situation Situation { get; set; }

        [JsonProperty("youtube_video")]
        public Video YoutubeVideo { get; set; }

    }
}