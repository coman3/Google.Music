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
    /// Interaction logic for NavItem.xaml
    /// </summary>
    public partial class NavItem : UserControl
    {
        public static readonly DependencyProperty IconBrushProperty =
            DependencyProperty.Register("IconBrush", typeof (VisualBrush), typeof (NavItem),
                new FrameworkPropertyMetadata(new VisualBrush()));
        public static readonly DependencyProperty HeadingProperty =
            DependencyProperty.Register("Heading", typeof (string), typeof (NavItem),
                new FrameworkPropertyMetadata(""));

        

        public VisualBrush IconBrush
        {
            get { return (VisualBrush)GetValue(IconBrushProperty); }
            set { SetValue(IconBrushProperty, value); }
        }
        public string Heading
        {
            get { return (string) GetValue(IconBrushProperty); }
            set { SetValue(IconBrushProperty, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                MainBorder.BorderThickness = new Thickness(value ? 5 : 0, 0, 0, 0);
                MainBorder.Margin = !value ? new Thickness(5) : new Thickness(0, 5, 5, 5);
                _isSelected = value;
            }
        }

        public NavItem()
        {
            InitializeComponent();
        }
    }
}
