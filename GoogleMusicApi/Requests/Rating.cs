using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    public class Rating
    {
        [JsonProperty("rating")]
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