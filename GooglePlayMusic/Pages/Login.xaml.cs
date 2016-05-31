using System;
using System.Windows;
using System.Windows.Controls;
using GoogleMusicApi;
using GoogleMusicApi.Common;
using GoogleMusicApi.Sessions;
using GooglePlayMusic.Desktop.Managers;

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
        }
        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            LoadingOverlay.Visibility = Visibility.Visible;
            SessionManager.MobileClient = new MobileClient();

            if (await SessionManager.MobileClient.LoginAsync(TextBoxUsername.Text, TextBoxPassword.Password))
            {

                WindowManager.NavigateToPage(new Uri("/Pages/Test.xaml", UriKind.Relative));
                LoadingOverlay.Visibility = Visibility.Hidden;
            }
            else
            {
                LoadingOverlay.Visibility = Visibility.Hidden;
                MessageBox.Show("Login Failed!");

            }
        }
    }
}
