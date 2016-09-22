using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    [JsonObject]
    public class Genre
    {
        [JsonProperty("children")]
        public string[] Children { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        public override string ToString()
        {
            return string.Join(" ", "Name:", Name);
        }
    }
}