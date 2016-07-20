using System.Runtime.Serialization;

namespace GoogleMusicApi.UWP.Structure.Enums
{
    public enum TabGenre
    {
        [DataMember(Name = "NEW_RELEASES")]
        NewReleases,
        [DataMember(Name = "ALTERNATIVE_INDIE")]
        AlternativeIndie,
        [DataMember(Name = "HIP_HOP_RAP")]
        HipHopRap,
        [DataMember(Name = "ROCK")]
        Rock,
        [DataMember(Name = "POP")]
        Pop,
        [DataMember(Name = "DANCE_ELECTRONIC")]
        DanceElectronic
    }

}