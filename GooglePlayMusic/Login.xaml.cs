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
using System.Windows.Shapes;
using GoogleMusicApi;

namespace GooglePlayMusic
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            SessionManager.CurrentWindow = this;
            InitializeComponent();
        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            LoadingOverlay.Visibility = Visibility.Visible;
            SessionManager.MobileSession = new MobileSession();

            if (await SessionManager.MobileSession.LoginAsync( TextBoxUsername.Text, TextBoxPassword.Password))
            {
                
                SessionManager.CurrentWindow = new MainWindow();
                SessionManager.CurrentWindow.Show();
                LoadingOverlay.Visibility = Visibility.Hidden;
                this.Close();
            }
            else
            {
                LoadingOverlay.Visibility = Visibility.Hidden;
                MessageBox.Show("Login Failed!");
                
            }
        }
    }
}
