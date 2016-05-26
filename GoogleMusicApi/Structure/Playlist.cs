using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Playlist
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TypeValue Type { get; set; }
        public enum TypeValue
        {
            [EnumMember(Value = "MAGIC")]
            Magic,
            [EnumMember(Value = "SHARED")]
            Shared,
            [EnumMember(Value = "USER_GENERATED")]
            UserGenerated,
        }
        [JsonProperty("lastModifiedTimestamp")]
        public string LastModifiedTimestamp { get; set; }
        [JsonProperty("recentTimestamp")]
        public string RecentTimestamp { get; set; }
        [JsonProperty("shareToken")]
        public string ShareToken { get; set; }
        [JsonProperty("ownerProfilePhotoUrl")]
        public string OwnerProfilePhotoUrl { get; set; }
        [JsonProperty("ownerName")]
        public string OwnerName { get; set; }
        [JsonProperty("accessControlled")]
        public bool AccessControlled { get; set; }
        [JsonProperty("shareState")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ShareStateValue ShareState { get; set; }
        public enum ShareStateValue
        {
            [EnumMember(Value = "PRIVATE")]
            Private,
            [EnumMember(Value = "PUBLIC")]
            Public,
        }
        [JsonProperty("creationTimestamp")]
        public string CreationTimestamp { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("albumArtRef")]
        public ArtReference[] AlbumArtRef { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("explicitType")]
        public string ExplicitType { get; set; }
        [JsonProperty("contentType")]
        public string ContentType { get; set; }



    }


}
