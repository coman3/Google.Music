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
using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;
using GooglePlayMusic.Desktop.Pages;

namespace GooglePlayMusic.Desktop.Common
{
    /// <summary>
    /// Interaction logic for CardList.xaml
    /// </summary>
    public partial class CardList : UserControl
    {
        public CardList()
        {
            InitializeComponent();
        }

        public void LoadData(ListListenNowSituationResponse data)
        {
            foreach (var situation in data.Situations)
            {
                var card = new Card
                {
                    ImageSource = new BitmapImage(new Uri(situation.ImageUrl)),
                    DescriptionText = situation.Description,
                    HeadingText = situation.Title,
                    Tag = situation,
                };
                card.MouseUp += Card_MouseUp;
                StackPanel.Children.Add(card);
            }
        }

        private void Card_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var card = sender as Card;

            if (card?.Tag is Situation) 
                    MainWindow.Navigate(new SituationPage((Situation) card.Tag));
        }
    }
}
