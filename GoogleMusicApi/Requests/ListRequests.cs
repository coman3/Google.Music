using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
{
    public class ListPlaylists : StructuredRequest<ResultListRequest, ResultList<Playlist>>
    {
        public override string RelativeRequestUrl => "playlistfeed";
    }
    public class ListPlaylistEntries : StructuredRequest<ResultListRequest, ResultList<Plentry>>
    {
        public override string RelativeRequestUrl => "plentryfeed";
    }
    public class ListTrackFeed : StructuredRequest<ResultListRequest, ResultList<Track>>
    {
        public override string RelativeRequestUrl => "trackfeed";
    }
    public class ListPromotedTracks : StructuredRequest<ResultListRequest, ResultList<Track>>
    {
        public override string RelativeRequestUrl => "ephemeral/top";
    }

    public class ListListenNowTracks : StructuredRequest<GetRequest, ListListenNowTracksResponse>
    {
        public override string RelativeRequestUrl => "listennow/getlistennowitems";
    }
}