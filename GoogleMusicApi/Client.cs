using GoogleMusicApi.Sessions;
using System.Threading.Tasks;

namespace GoogleMusicApi
{
    /// <summary>
    /// A Client to access Google Play Music
    /// </summary>
    /// <typeparam name="TSession">The Session Type, such as <see cref="MobileSession"/> (Only One Supported Currently)</typeparam>
    //TODO (Low): Create Other Types Of Clients
    public abstract class Client<TSession>
        where TSession : Session
    {
        /// <summary>
        /// The Current Authorization Token being used.
        /// </summary>
        /// <remarks>
        /// This is also found within the <see cref="Session"/> but is contained here for ease of access.
        /// </remarks>
        public virtual string AuthorizationToken => Session.AuthorizationToken;

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
        public abstract bool Login(string email, string password);

        /// <summary>
        /// Execute <seealso cref="Login"/> asynchronously.
        /// </summary>
        /// <param name="username">The Email / Username of the google account</param>
        /// <param name="password">The Password</param>
        /// <returns>True if successful, false otherwise</returns>
        public async Task<bool> LoginAsync(string username, string password)
        {
            return await Task.Factory.StartNew(() => Login(username, password));
        }
    }
}