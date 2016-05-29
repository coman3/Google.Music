using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMusicApi.Requests;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Common
{
    /// <summary>
    /// An Easy to use Google Play Music Client, that can do everything but upload music.
    ///  
    /// </summary>
    public class MobileClient : Client<MobileSession>
    {
        /// <summary>
        /// Create a new <see cref="MobileClient"/>.
        /// </summary>
        public MobileClient()
        {

        }

        /// <summary>
        /// Create a <see cref="MobileClient"/> that has previously been logged in, using the specified Authorization Token.
        /// </summary>
        /// <param name="token">The Previous Authorization Token. </param>
        /// <remarks>
        /// To Check if the Authorization Token is still valid see: <seealso cref="LoginCheck"/> 
        /// </remarks>
        public MobileClient(string token)
        {

        }

        #region Privates
        private bool CheckSession()
        {
#if DEBUG
            if (Session == null)
                throw new InvalidOperationException("Session Not Set! Try logging in again.");
            if (Session.AuthorizationToken == null)
                throw new InvalidOperationException(
                    "Session does not contain an Authorization Token! Try logging in again.");
#else
            if (Session?.AuthorizationToken != null) 
                return true;
#endif
            return false;
        }
        private TReuqest MakeRequest<TReuqest>()
            where TReuqest : StructuredRequest, new()
        {
            return new TReuqest();
        }
        #endregion

        #region Account

        /// <summary>
        /// Login to Google Play Music with the specified email and password.
        /// This will make two requests to the Google Authorization Server, and collect an Authorization Token to use for all requests.
        /// </summary>
        /// <param name="email">The Email / Username of the google account</param>
        /// <param name="password">The Password / App Specific password (https://security.google.com/settings/security/apppasswords)</param>
        public sealed override bool Login(string email, string password)
        {
            Debug.WriteLine($"Attempting Login ({email})...");

            Session = new MobileSession();
            return Session.Login(email, password);
        }

        /// <summary>
        /// Check if the specified Authorization Token is still valid, and if it is collect required information to login.
        /// </summary>
        /// <param name="token">The Authorization Token, if left null will use the Authorization Token associated to this <see cref="MobileClient"/> (If specified in constructor)</param>
        /// <returns></returns>
        public bool LoginCheck(string token = null)
        {

            //TODO (Medium): Implement Token Check
            throw new NotSupportedException();
/*
            if (token == null && AuthorizationToken == null)
                throw new ArgumentException("Please specify an Authorization Token", nameof(token));
            if(token == null) token = AuthorizationToken;

            Debug.WriteLine($"Checking Token ({token})...");

            return false;
*/
        }
        #endregion

        #region List Requests

        /// <summary>
        /// Gets the current Situations. Suggestions
        /// </summary>
        /// <param name="situationType">The situation types you wish to receive</param>
        /// <returns>
        /// Information like:
        ///  - "Its Friday Morning..." : "Play Music for..."
        ///     - "Todays Biggest Hits"
        ///         - "Today's Dance Smashes"
        ///         - "Today's Pop Charts"
        ///         - "..."
        ///     - "Waking Up Happy"
        ///         - "Star Guitars"
        ///             - "Air Guitar Heroes"
        ///             - "..."
        ///         - "..."
        /// All Data above will also have <see cref="ArtReference"/>'s for each station / situation
        /// </returns>
        //TODO (Low): Find out what situation types exist
        //TODO (Medium): Convert the int[] to a SituationType[]
        public ListListenNowSituationResponse ListListenNowSituations(params int[] situationType)
        {
            if (!CheckSession())
                return null;
            if (situationType == null)
            {
                situationType = new[] {1};
            }
            var requestData = new ListListenNowSituationsRequest(Session)
            {
                RequestSignals = new RequestSignal(RequestSignal.GetTimeZoneOffsetSecs()),
                SituationType = situationType

            };

            var request = MakeRequest<ListListenNowSituations>();
            var data = request.Get(requestData);
            return data;
        }

        /// <summary>
        /// Runs <seealso cref="ListListenNowSituations"/> Asynchronously.
        /// </summary>
        /// <param name="situationType">The situation types you wish to receive</param>
        /// <returns>The value returned from <seealso cref="ListListenNowSituations"/></returns>

        public async Task<ListListenNowSituationResponse> ListListenNowSituationsAsync(params int[] situationType)
        {
            return await Task.Factory.StartNew(() => ListListenNowSituations(situationType));
        }

        /// <summary>
        /// Gets a list of suggestions (Albums or Stations).
        /// </summary>
        /// <returns>
        /// Information like:
        /// - "Skin" : "Flume" : "Skin is a music album by Flume"
        ///     - Reason: "New Release because you like this artist"
        /// - "Tourist Radio"
        ///     - Reason: "Similar to Hayden James"
        /// Each Entry will have two images, one with an aspect ratio of 1 and another with aspect ratio of 2.
        /// Each Entry will contain either a RadioStation or an Album, never both.
        /// </returns>
        //TODO (Low): Change ListenNowItem Type to Enum
        public ListListenNowTracksResponse ListListenNowTracks()
        {
            if (!CheckSession())
                return null;

            var request = MakeRequest<ListListenNowTracks>();
            var data = request.Get(new GetRequest(Session));
            return data;
        }

        /// <summary>
        /// Runs <seealso cref="ListListenNowTracks"/> Asynchronously.
        /// </summary>
        /// <returns>The value returned from <seealso cref="ListListenNowTracks"/></returns>
        public async Task<ListListenNowTracksResponse> ListListenNowTracksAsync()
        {
            return await Task.Factory.StartNew(ListListenNowTracks);
        }


        /// <summary>
        /// Gets a list of <see cref="Playlist"/>'s associated to the account
        /// </summary>
        /// <param name="numberOfResults">How many playlists you wish to receive</param>
        /// <returns>
        /// A DataSet of <see cref="Playlist"/>'s
        /// 
        /// Future - TODO (Medium): Add Support for NextPageToken
        /// </returns>
        public ResultList<Playlist> ListPlaylists(int numberOfResults = 50)
        {
            if (!CheckSession())
                return null;
            var request = MakeRequest<ListPlaylists>();
            var data = request.Get(new ResultListRequest(Session)
            {
                MaxResults = numberOfResults
            });
            return data;
        }

        /// <summary>
        /// Runs <seealso cref="ListPlaylists"/> Asynchronously.
        /// </summary>
        /// <param name="numberOfResults">How many playlists you wish to receive</param>
        /// <returns>The value returned from <seealso cref="ListPlaylists"/></returns>
        public async Task<ResultList<Playlist>> ListPlaylistsAsync(int numberOfResults = 50)
        {
            return await Task.Factory.StartNew(() => ListPlaylists(numberOfResults));
        }

        /// <summary>
        /// Gets a list of promoted <see cref="Track"/>'s
        /// </summary>
        /// <param name="numberOfResults">How many playlists you wish to receive</param>
        /// <returns>
        /// A DataSet of <see cref="Playlist"/>'s
        /// Future - TODO (Low): Maybe Thumbs Up List?
        /// Future - TODO (Medium): Add Support for NextPageToken
        /// </returns>

        public ResultList<Track> ListPromotedTracks(int numberOfResults = 1000)
        {
            if (!CheckSession())
                return null;

            var request = MakeRequest<ListPromotedTracks>();
            var data = request.Get(new ResultListRequest(Session)
            {
                MaxResults = numberOfResults
            });
            return data;

        }

        /// <summary>
        /// Runs <seealso cref="ListPromotedTracks"/> Asynchronously.
        /// </summary>
        /// <param name="numberOfResults">How many playlists you wish to receive</param>
        /// <returns>The value returned from <seealso cref="ListPromotedTracks"/></returns>
        public async Task<ResultList<Track>> ListPromotedTracksAsync(int numberOfResults = 1000)
        {
            return await Task.Factory.StartNew(() => ListPromotedTracks(numberOfResults));
        }

        /// <summary>
        /// Gets a list of <see cref="StationCategory"/>'s.
        /// This is the same as "Browse Stations" on the mobile interface
        /// </summary>
        /// <returns>
        /// Information like:
        ///   - "Root"
        ///     - "Genres"
        ///         - "..."
        ///     - "Activities"
        ///         - "..."
        ///     - "Moods"
        ///         -"..."
        /// </returns>
        public ListStationCategoriesResponse ListStationCategories()
        {
            if (!CheckSession())
                return null;
            var request = MakeRequest<ListStationCategories>();
            var data = request.Get(new GetRequest(Session));
            return data;
        }

        /// <summary>
        /// Runs <seealso cref="ListStationCategories"/> Asynchronously.
        /// </summary>
        /// <returns>The value returned from <seealso cref="ListStationCategories"/></returns>
        public async Task<ListStationCategoriesResponse> ListStationCategoriesAsync()
        {
            return await Task.Factory.StartNew(ListStationCategories);
        }

        #endregion

        #region Gets

        /// <summary>
        /// Get the Google Play Music configuration key / values
        /// </summary>
        /// <returns>Your current Google Play Music configuration</returns>
        public Config GetConfig()
        {
            if (!CheckSession())
                return null;
            var request = MakeRequest<GetConfig>();
            var data = request.Get(new GetRequest(Session));
            return data;

        }

        /// <summary>
        /// Runs <seealso cref="GetConfig"/> Asynchronously.
        /// </summary>
        /// <returns>The value returned from <seealso cref="GetConfig"/></returns>
        public async Task<Config> GetConfigAsync()
        {
            return await Task.Factory.StartNew(GetConfig);
        }

        public GetRadioStationAnnotationResponse GetRadioStationAnnotation(StationSeed seed)
        {
            if (!CheckSession())
                return null;
            if (seed.CuratedStationId == null)
                return null;

            var request = MakeRequest<GetRadioStationAnnotation>();
            var data = request.Get(new GetRadioStationAnnotationRequest(Session, seed));
            return data;
        } 

        public async Task<GetRadioStationAnnotationResponse> GetRadioStationAnnotationAsync(StationSeed seed)
        {
            return await Task.Factory.StartNew(() => GetRadioStationAnnotation(seed));
        } 

        public string GetStreamUrl(Track track)
        {
            if (!CheckSession())
                return null;
            var request = MakeRequest<GetStreamUrl>();
            var data = request.Get(new StreamUrlGetRequest(Session, track));
            return data;
        } 

        public async Task<string> GetStreamUrlAsync(Track track)
        {
            return await Task.Factory.StartNew(() => GetStreamUrl(track));
        } 

        public Track GetTrack(string trackId)
        {
            if (!CheckSession())
                return null;

            var request = MakeRequest<GetTrack>();
            var data = request.Get(new GetTrackRequest(Session, trackId));
            return data;
        } 

        public async Task<Track> GetTrackAsync(string trackId)
        {
            return await Task.Factory.StartNew(() => GetTrack(trackId));
        }


        #endregion

        #region Other
        public SearchResponse Search(string query)
        {
            if (!CheckSession())
                return null;
            var request = MakeRequest<ExecuteSearch>();
            var data = request.Get(new SearchGetRequest(Session, query));
            return data;
        } 

        public async Task<SearchResponse> SearchAsync(string query)
        {
            return await Task.Factory.StartNew(() => Search(query));
        } 

        public EditRadioStationReponse EditRadioStation(params EditRadioStationRequestMutation[] requestData)
        {
            if (!CheckSession())
                return null;

            var request = MakeRequest<EditRadioStation>();
            var data = request.Get(new EditRadioStationRequest(Session, requestData));
            return data;
        }

        public async Task<EditRadioStationReponse> EditRadioStationAsync(params EditRadioStationRequestMutation[] requestData)
        {
            return await Task.Factory.StartNew(() => EditRadioStation(requestData));
        } 

        #endregion

    }
}
