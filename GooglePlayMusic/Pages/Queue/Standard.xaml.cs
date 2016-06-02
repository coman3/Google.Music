using System.Windows;
using System.Windows.Controls;
using GooglePlayMusic.Desktop.Managers;

namespace GooglePlayMusic.Desktop.Pages.Queue
{
    /// <summary>
    /// Interaction logic for Standard.xaml
    /// </summary>
    public partial class Standard : Page
    {
        public Standard()
        {
            InitializeComponent();
            TrackManager.OnQueueChange += TrackManager_OnQueueChange;
        }

        private void TrackManager_OnQueueChange(object sender, QueueChangeEventArgs args)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(() => { TrackManager_OnQueueChange(sender, args); });
                return;
            }
            DataGrid.ItemsSource = TrackManager.Queue;
            DataGrid.AutoGenerateColumns = true;
            DataGrid.Items.Refresh();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
