using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GoogleMusicApi;
using GoogleMusicApi.Authentication;
using GoogleMusicApi.Common;
using GoogleMusicApi.Sessions;
using GooglePlayMusic.Desktop.Managers;
using GooglePlayMusic.Desktop.Properties;

namespace GooglePlayMusic.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            this.Loaded += Login_Loaded;
        }

        private async void Login_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Settings.Default.UserMasterToken) && !string.IsNullOrEmpty(Settings.Default.UserEmail))
            {
                LoadingOverlay.Visibility = Visibility.Visible;
                SessionManager.MobileClient = new MobileClient();

                if (await SessionManager.MobileClient.LoginWithToken(Settings.Default.UserEmail, StringCipher.Decrypt(Settings.Default.UserMasterToken, GoogleAuth.GetPcMacAddress())))
                {
                    FinishLogin();
                    return;
                }
                LoadingOverlay.Visibility = Visibility.Hidden;
            }
        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            LoadingOverlay.Visibility = Visibility.Visible;
            SessionManager.MobileClient = new MobileClient();

            if (await SessionManager.MobileClient.LoginAsync(TextBoxUsername.Text, TextBoxPassword.Password))
            {
                Settings.Default.UserEmail = SessionManager.MobileClient.Session.UserDetails.Email;
                Settings.Default.UserMasterToken = StringCipher.Encrypt(SessionManager.MobileClient.Session.MasterToken, GoogleAuth.GetPcMacAddress());
                Settings.Default.Save();
                FinishLogin();
            }
            else
            {
                LoadingOverlay.Visibility = Visibility.Hidden;
                MessageBox.Show("Login Failed!");

            }
        }

        private void FinishLogin()
        {
            WindowManager.NavigateToPage(new Uri("/Pages/Index.xaml", UriKind.Relative));
            LoadingOverlay.Visibility = Visibility.Hidden;
        }
    }
}
