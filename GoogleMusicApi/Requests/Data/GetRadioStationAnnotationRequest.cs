using System;
using System.Collections.Generic;
using System.Text;
using GoogleMusicApi.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.Requests
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GetRadioStationAnnotationRequest : PostRequest
    {
        public GetRadioStationAnnotationRequest(Session session, StationSeed seed) : base(session)
        {
            if (string.IsNullOrWhiteSpace(seed.CuratedStationId))
                throw new ArgumentException("Seed is not a station or does not include the " +
                                            nameof(seed.CuratedStationId) + "value!");

            IncludeAlbumQuilt = true;
            Seed = seed;

            NumberOfFeaturedArtists = 25;
            NumberOfSimilarStations = 25;

            UrlData = new WebRequestHeaders
            {
                new WebRequestHeader("alt", "json"),
                new WebRequestHeader("hl", "en_AU")
            };
        }

        [JsonProperty("includeAlbumQuilt")]
        public bool IncludeAlbumQuilt { get; set; }

        [JsonProperty("numFeaturedArtists")]
        public int NumberOfFeaturedArtists { get; set; }

        [JsonProperty("numSimilarStations")]
        public int NumberOfSimilarStations { get; set; }

        [JsonProperty("seed")]
        public StationSeed Seed { get; set; }

        [JsonProperty("supportedStationAnnotationPlayableItemTypes")]
        public string[] SupportedStationAnnotationPlayableItemTypes { get; set; } //TODO: Array of?

        public override byte[] GetRequestBody()
        {
            var json = JsonConvert.SerializeObject(this, Formatting.None,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
            return Encoding.UTF8.GetBytes(json);
        }
    }
}