using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Situation
    {
         [JsonProperty("id")]
         public string Id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("wideImageUrl")]
        public string WideImageUrl { get; set; }
        [JsonProperty("stations")]
        public Station[] Stations { get; set; }

    }
}