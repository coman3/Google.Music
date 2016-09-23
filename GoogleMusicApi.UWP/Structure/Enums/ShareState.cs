using System.Runtime.Serialization;

namespace GoogleMusicApi.UWP.Structure.Enums
{
    public enum ShareState
    {
        [EnumMember(Value = "PRIVATE")]
        Private,

        [EnumMember(Value = "PUBLIC")]
        Public
    }
}