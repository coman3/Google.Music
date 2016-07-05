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

namespace SpotifyToGoogle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            if (Instance == null)
                Instance = this;
            else
                return;
            InitializeComponent();
        }

        public static void NavigateNew(ApiType type, Uri uri)
        {
            switch (type)
            {
                case ApiType.Google:
                    Instance.GoogleNav.Navigate(uri);
                    break;
                case ApiType.Spotify:
                    Instance.SpotifyNav.Navigate(uri);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public enum ApiType
        {
            Google,
            Spotify
        }
    }
}
