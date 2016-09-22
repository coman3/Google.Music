using System.Runtime.Serialization;

namespace GoogleMusicApi.Structure.Enums
{
    public enum ShareState
    {
        [EnumMember(Value = "PRIVATE")]
        Private,

        [EnumMember(Value = "PUBLIC")]
        Public
    }
}