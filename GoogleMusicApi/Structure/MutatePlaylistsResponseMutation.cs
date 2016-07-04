using GoogleMusicApi.Structure.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleMusicApi.Structure
{
    public class MutatePlaylistsResponseMutation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("response_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseCode ResponseCode { get; set; }
    }
}