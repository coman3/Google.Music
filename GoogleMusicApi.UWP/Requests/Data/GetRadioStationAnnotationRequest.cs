using System;
using GoogleMusicApi.UWP.Sessions;
using GoogleMusicApi.UWP.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests.Data
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GetRadioStationAnnotationRequest : PostRequest
    {
        [JsonProperty("includeAlbumQuilt")]
        public bool IncludeAlbumQuilt { get; set; }

        [JsonProperty("numFeaturedArtists")]
        public int NumberOfFeaturedArtists { get; set; }

        [JsonProperty("numSimilarStations")]
        public int NumberOfSimilarStations { get; set; }

        [JsonProperty("seed")]
        public StationSeed Seed { get; set; }

        [JsonProperty("supportedStationAnnotationPlayableItemTypes")]
        public string[] SupportedStationAnnotationPlayableItemTypes { get; set; }

        public GetRadioStationAnnotationRequest(Session session, StationSeed seed) : base(session)
        {
            if (string.IsNullOrWhiteSpace(seed.CuratedStationId))
                throw new ArgumentException("Seed is not a station or does not include the " +
                                            nameof(seed.CuratedStationId) + "value!");

            IncludeAlbumQuilt = true;
            Seed = seed;

            NumberOfFeaturedArtists = 25;
            NumberOfSimilarStations = 25;
        }

        //TODO: Array of?
    }
}