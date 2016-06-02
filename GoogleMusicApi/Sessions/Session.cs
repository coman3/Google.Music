using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleMusicApi.Sessions
{
    public abstract class Session
    {
        public string AuthorizationToken { get; protected set; }

        public string FirstName { get; protected set; }

        public HttpClient HttpClient { get; protected set; }

        public bool IsAuthenticated { get; protected set; }

        public string LastName { get; protected set; }

        public abstract Task<bool> LoginAsync();
        public abstract Task<bool> LoginAsync(string masterToken);

        public abstract void ResetHeaders();
    }
}