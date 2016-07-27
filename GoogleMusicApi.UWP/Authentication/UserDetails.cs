namespace GoogleMusicApi.UWP.Authentication
{
    public sealed class UserDetails
    {
        public string AndroidId { get; }

        public string Email { get; }

        public string Password { get; private set; }

        public UserDetails(string email, string password, string androidId)
        {
            Email = email;
            Password = password;
            AndroidId = androidId;
        }

        public void ClearPassword()
        {
            Password = null;
        }
    }
}