using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Structure
{
    public class AlbumQuilt
    {
        [JsonProperty("artworks")]
        public ArtReference[] Artworks { get; set; }
    }
}