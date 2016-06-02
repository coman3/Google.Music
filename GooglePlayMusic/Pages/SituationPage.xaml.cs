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
using GoogleMusicApi.Structure;

namespace GooglePlayMusic.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for SituationPage.xaml
    /// </summary>
    public partial class SituationPage : Page
    {
        public Situation Situation { get; set; }
        public SituationPage(Situation situation)
        {
            InitializeComponent();
            Situation = situation;
        }
    }
}
