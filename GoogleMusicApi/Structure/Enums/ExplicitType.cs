using System.Runtime.Serialization;

namespace GoogleMusicApi.Structure.Enums
{
    public enum ExplicitType
    {
        [EnumMember(Value = "1")]
        Explicit = 1,
        [EnumMember(Value = "2")]
        NonExplicit = 2
    }
}