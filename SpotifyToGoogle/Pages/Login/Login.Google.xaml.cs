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
using GoogleMusicApi.Common;

namespace SpotifyToGoogle
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginGoogle : Page
    {
        public LoginGoogle()
        {
            InitializeComponent();
        }

        private async void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            var client = new MobileClient();
            if (await client.LoginAsync(Username.Text, Password.Password))
            {
                SessionManager.GoogleClient = client;
                LoginButton.IsEnabled = false;
                SessionManager.CheckNextStep();
            }
            else
            {
                MessageBox.Show("Login Failed.");
                //TODO: Pretty up
            }
        }
    }
}
