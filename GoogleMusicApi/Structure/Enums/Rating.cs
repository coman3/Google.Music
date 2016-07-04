using System.Runtime.Serialization;

namespace GoogleMusicApi.Structure.Enums
{
    public enum Rating
    {
        [EnumMember(Value = "FIVE_STARS")]
        FiveStars,

        [EnumMember(Value = "NO_RATING")]
        NoRating,

        [EnumMember(Value = "ONE_STAR")]
        OneStar
    }
}