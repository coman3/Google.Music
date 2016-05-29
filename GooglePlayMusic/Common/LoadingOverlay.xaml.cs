using System.Windows.Controls;
using System.Windows.Media;

namespace GooglePlayMusic.Desktop.Common
{
    /// <summary>
    /// Interaction logic for LoadingOverlay.xaml
    /// </summary>
    public partial class LoadingOverlay : UserControl
    {
        
        public LoadingOverlay()
        {
            InitializeComponent();
        }

        public void SetSolid()
        {
            Grid.Background = Brushes.Black;
        }
        public void SetNonSoild()
        {
            Grid.Background = new SolidColorBrush(Colors.Black)
            {
                Opacity = 80,
            };
        }
    }
}
