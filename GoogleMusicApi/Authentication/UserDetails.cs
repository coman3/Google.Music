using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleMusicApi.Authentication
{
    public sealed class UserDetails
    {
        public string AndroidId { get; }

        public string EMail { get; }

        public string Password { get; }

        public UserDetails(string email, string password, string androidId)
        {
            EMail = email;
            Password = password;
            AndroidId = androidId;
        }
    }
}