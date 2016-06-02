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
            MainWindow.HideNavs();

            if (string.IsNullOrWhiteSpace(Settings.Default.UserEmail) || string.IsNullOrWhiteSpace(Settings.Default.UserMasterToken)) return;
            LoadingOverlay.Visibility = Visibility.Visible;
            Loaded += Login_Loaded;

        }

        private async void Login_Loaded(object sender, RoutedEventArgs e)
        {
            SessionManager.MobileClient = new MobileClient();

            if (await SessionManager.MobileClient.LoginWithToken(Settings.Default.UserEmail,
                        StringCipher.Decrypt(Settings.Default.UserMasterToken, GoogleAuth.GetPcMacAddress())))
            {
                FinishLogin();
            }
            else
            {
                LoadingOverlay.Visibility = Visibility.Hidden;
            }
            
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text)) return;
            if (string.IsNullOrWhiteSpace(PasswordTextBox.Password)) return;

            LoadingOverlay.Visibility = Visibility.Visible;
            SessionManager.MobileClient = new MobileClient();

            if (await SessionManager.MobileClient.LoginAsync(UsernameTextBox.Text, PasswordTextBox.Password))
            {
                Settings.Default.UserEmail = UsernameTextBox.Text;
                Settings.Default.UserMasterToken = StringCipher.Encrypt(PasswordTextBox.Password,
                    GoogleAuth.GetPcMacAddress());
                Settings.Default.Save();
                FinishLogin();
            }
            else
            {
                MessageBox.Show(
                    "Incorrect Username or Password!\nPlease make sure 2 factor authentication is disabled, or you are using an application password.",
                    "Login Failed!");
                LoadingOverlay.Visibility = Visibility.Hidden;
            }
        }

        private void FinishLogin()
        {
            MainWindow.ShowNavs();
            MainWindow.Navigate("/Pages/ListenNow.xaml", false);
            
            LoadingOverlay.Visibility = Visibility.Hidden;
        }
    }
}
