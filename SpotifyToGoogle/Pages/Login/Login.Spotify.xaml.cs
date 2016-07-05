using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using MessageBox = System.Windows.MessageBox;

namespace SpotifyToGoogle
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginSpotify : Page
    {
        public ImplicitGrantAuth ImplicitGrantAuth { get; set; }
        public LoginSpotify()
        {
            InitializeComponent();
            ImplicitGrantAuth = new ImplicitGrantAuth
            {
                RedirectUri = "http://localhost:8000",
                ClientId = "7cbd39978c96464099ce4d03c98cb739",
                Scope = Scope.UserReadPrivate | Scope.UserReadEmail | Scope.PlaylistReadPrivate | Scope.UserLibraryRead | Scope.UserReadPrivate | Scope.UserFollowRead | Scope.UserReadBirthdate | Scope.UserTopRead,
                State = "XSS"
            };
            ImplicitGrantAuth.OnResponseReceivedEvent += _auth_OnResponseReceivedEvent;
        }

        private async void _auth_OnResponseReceivedEvent(Token token, string state)
        {
            ImplicitGrantAuth.StopHttpServer();

            if (state != "XSS")
            {
                MessageBox.Show(@"Wrong state received.", @"SpotifyWeb API Error");
                return;
            }
            if (token.Error != null)
            {
                MessageBox.Show($"Error: {token.Error}", @"SpotifyWeb API Error");
                return;
            }

            SessionManager.SpotifyClient = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };
            SessionManager.SpotifyProfile = await SessionManager.SpotifyClient.GetPrivateProfileAsync();
            FinalizeLogin();
        }

        private void FinalizeLogin()
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(FinalizeLogin);
                return;
            }
            LoginButton.IsEnabled = false;
            SessionManager.CheckNextStep();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            ImplicitGrantAuth.StartHttpServer(8000);
            ImplicitGrantAuth.DoAuth();
        }
    }
}
