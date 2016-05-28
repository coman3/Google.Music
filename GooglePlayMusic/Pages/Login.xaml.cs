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
using GoogleMusicApi;
using GooglePlayMusic.Managers;

namespace GooglePlayMusic.Pages
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
            SessionManager.MobileSession = new MobileSession();

            if (await SessionManager.MobileSession.LoginAsync(TextBoxUsername.Text, TextBoxPassword.Password))
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
