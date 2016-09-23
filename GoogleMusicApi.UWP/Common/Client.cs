using System.Threading.Tasks;
using GoogleMusicApi.UWP.Sessions;

namespace GoogleMusicApi.UWP.Common
{
    /// <summary>
    /// A Client to access Google Play Music
    /// </summary>
    /// <typeparam name="TSession">The Session PlaylistType, such as <see cref="MobileSession"/> (Only One Supported Currently)</typeparam>
    //TODO (Low): Create Other Types Of Clients
    public abstract class Client<TSession>
        where TSession : Session
    {
        /// <summary>
        /// The Current Session with Google Play Music
        /// </summary>
        public TSession Session { get; set; }

        /// <summary>
        /// Login to Google Play Music with the specified email and password.
        /// </summary>
        /// <param name="email">The Email / Username of the google account</param>
        /// <param name="password">The Password</param>
        /// <returns>True if successful, false otherwise</returns>
        public abstract Task<bool> LoginAsync(string email, string password);

    }
}