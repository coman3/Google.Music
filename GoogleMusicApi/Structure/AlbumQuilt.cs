using Newtonsoft.Json;

namespace GoogleMusicApi.Structure
{
    public class AlbumQuilt
    {
        [JsonProperty("artworks")]
        public ArtReference[] Artworks { get; set; }
    }
}