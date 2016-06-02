using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GooglePlayMusic.Desktop.Common;


namespace GooglePlayMusic.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static MainWindow Instance { get; private set; }

        public static Stack<Page> PreviousPages { get; set; } 
        public MainWindow()
        {
            if(Instance != null) throw new Exception("Window Already Open!");
            PreviousPages = new Stack<Page>(10);
            Instance = this;
            InitializeComponent();
            ContructAccountMenu();
        }

        public static void ShowNavs()
        {
            Instance.LeftNavColumn.Width = new GridLength(180);
            Instance.TopNavRow.Height = new GridLength(60);
        }
        public static void HideNavs()
        {
            Instance.LeftNavColumn.Width = new GridLength(0);
            Instance.TopNavRow.Height = new GridLength(0);
        }
        #region Top Menu Events

        #region File

        private void File_NewPlaylist_Click(object sender, RoutedEventArgs e)
        {

        }

        private void File_Import_WMP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void File_Import_Itunes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void File_Import_Spotify_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Playback

        private void Playback_Play_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Playback_Pause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Plaback_NextTrack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Playback_PrevTrack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Playback_Shuffle_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Playback_Repeat_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Playback_VolumeUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Playback_VolumeDown_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Account

        private void ContructAccountMenu()
        {
            //TODO (Low): List Accounts under Seperator, and allow switching
        }

        private void Account_Logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Account_AddAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Help

        private void Help_OfficalHelp_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://support.google.com/googleplay");
        }

        private void Help_ApplicationHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Help_AboutApplication_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Help_GithubProjectPage_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/coman3/Google.Music");
        }

        #endregion

        #endregion

        #region Left Nav Events

        private void Browse_ListenNow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SelectNavItem(sender as NavItem);
            Navigate("/Pages/ListenNow.xaml");
        }

        private void Browse_NewReleases_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SelectNavItem(sender as NavItem);
            Navigate("/Pages/NewReleases.xaml");
        }

        private void Browse_BrowseStations_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SelectNavItem(sender as NavItem);
            Navigate("/Pages/BrowseStations.xaml");
        }

        #endregion

        private void SelectNavItem(NavItem item)
        {
            DeselectAll_LeftNav();
            item.IsSelected = true;
        }

        private void DeselectAll_LeftNav()
        {
            foreach (var navItem in LeftNavStackPanel.Children.OfType<NavItem>())
            {
                navItem.IsSelected = false;
            }
        }

        public static void Navigate(string location, bool keeprevious = true)
        {
            if(keeprevious)
                PreviousPages.Push((Page)Instance.Frame.Content);
            Instance.Frame.Navigate(new Uri(location, UriKind.Relative));
            
        }

        public static void Navigate(object item, bool keeprevious = true)
        {
            var page = item as Page;
            if (page == null) return;
            if(keeprevious)
                PreviousPages.Push((Page)Instance.Frame.Content);
            Instance.Frame.Navigate(page);
        }

        private void TopNav_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //TODO (High): Impliment Search
                MessageBox.Show("Not Implimented");
            }
        }

        private void TopNav_Back_Click(object sender, RoutedEventArgs e)
        {
            if(PreviousPages.Count > 0)
            {
                Frame.Content = PreviousPages.Pop();
            }
        }
    }
}
