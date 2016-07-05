using System.Runtime.Serialization;

namespace GoogleMusicApi.Structure.Enums
{
    public enum ResponseCode
    {
        [DataMember(Name = "OK")]
        Ok,
        [DataMember(Name = "INVALID")]
        Invalid
    }
}