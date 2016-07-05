using GoogleMusicApi.Structure.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleMusicApi.Structure.Mutations
{
    public class ResponseMutation : Mutation
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("response_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseCode ResponseCode { get; set; }
    }
}