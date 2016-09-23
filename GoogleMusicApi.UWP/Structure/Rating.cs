using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleMusicApi.UWP.Structure
{
    public class Rating
    {
        [JsonProperty("rating")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.Rating RatingValue { get; set; }

        
    }
}