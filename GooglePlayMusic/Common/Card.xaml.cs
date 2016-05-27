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

namespace GooglePlayMusic.Common
{

    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public ImageSource Image
        {
            get { return ImageContainer.Source; }
            set { ImageContainer.Source = value; }
        }

        public string Header
        {
            get { return HeaderLabel.Text; }
            set { HeaderLabel.Text = value; }
        }
        public string Description
        {
            get { return DescriptionLabel.Text; }
            set { DescriptionLabel.Text = value; }
        }


        public Card() : this(null, "{Binding}", "{Binding}")
        {
        }

        public Card(ImageSource image, string title, string description)
        {
            InitializeComponent();
            Image = image;
            Header = title;
            Description = description;
        }

        private void ImageContainer_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
