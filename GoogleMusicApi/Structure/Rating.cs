using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleMusicApi.Structure
{
    public class Rating
    {
        [JsonProperty("rating")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RatingEnum RatingValue { get; set; }


        public enum RatingEnum
        {
            [EnumMember(Value = "FIVE_STARS")]
            FiveStars,
            [EnumMember(Value = "NO_RATING")]
            NoRating,
            [EnumMember(Value = "ONE_STAR")]
            OneStar
        }
    }
}