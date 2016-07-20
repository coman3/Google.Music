using System.Runtime.Serialization;

namespace GoogleMusicApi.UWP.Structure.Enums
{
    public enum PlaylistType
    {
        [EnumMember(Value = "MAGIC")]
        Magic,

        [EnumMember(Value = "SHARED")]
        Shared,

        [EnumMember(Value = "USER_GENERATED")]
        UserGenerated
    }
}