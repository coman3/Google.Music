using System.Net.Http;
using GoogleMusicApi.Common;
using GoogleMusicApi.Sessions;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{

    public class EditPlaylist : StructuredRequest<EditPlaylistRequest, Playlist>
    {
        public override string RelativeRequestUrl => "playlists";
    }

    public class EditPlaylistRequest : PutRequest
    {

        public Playlist Playlist { get; set; }

        public EditPlaylistRequest(Playlist modifiedPlaylist, Session session) : base(modifiedPlaylist.Id, session)
        {
            Playlist = modifiedPlaylist;
        }

        public override HttpContent GetRequestContent()
        {
            var playlist = new Playlist //Strip Unnecessary Values
            {
                CreationTimestamp = "-1",
                Deleted = Playlist.Deleted,
                Description = Playlist.Description,
                Id = Playlist.Id,
                LastModifiedTimestamp = Time.GetCurrentTimestampMicros(),
                Name = Playlist.Name,
                OwnerName = Playlist.OwnerName,
                OwnerProfilePhotoUrl = Playlist.OwnerProfilePhotoUrl,
                ShareState = Playlist.ShareState,
                ShareToken = Playlist.ShareToken,
                PlaylistType = Playlist.PlaylistType
            };
            return BuildHttpContent(playlist);
        }
    }
}