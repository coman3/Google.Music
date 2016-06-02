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

namespace GooglePlayMusic.Desktop.Common
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {

        public ImageSource ImageSource
        {
            get { return Image.Source; }
            set { Image.Source = value; }
        }

        public string HeadingText
        {
            get { return Heading.Text; }
            set { Heading.Text = value; }
        }
        public string DescriptionText
        {
            get { return Description.Text; }
            set { Description.Text = value; }
        }
        public Card()
        {
            InitializeComponent();
        }
    }
}
