using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Situation
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("situations")]
        public Situation[] Situations { get; set; }

        [JsonProperty("stations")]
        public Station[] Stations { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("wideImageUrl")]
        public string WideImageUrl { get; set; }

        public override string ToString()
        {
            return string.Join(" ", "Title:", Title);
        }
    }
}