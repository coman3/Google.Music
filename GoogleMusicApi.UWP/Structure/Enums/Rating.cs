﻿using System.Runtime.Serialization;

namespace GoogleMusicApi.UWP.Structure.Enums
{
    public enum Rating
    {
        [EnumMember(Value = "FIVE_STARS")]
        FiveStars,

        [EnumMember(Value = "NOT_RATED")]
        NoRating,

        [EnumMember(Value = "ONE_STAR")]
        OneStar
    }
}