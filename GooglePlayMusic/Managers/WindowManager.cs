using System;
using System.Windows;

namespace GooglePlayMusic.Desktop.Managers
{
    public static class WindowManager
    {
        public static Window CurrentWindow { get; set; }
        public static Action<Uri> NavigateToAction { get; set; }

        public static void NavigateToPage(Uri page)
        {
            NavigateToAction?.Invoke(page);
        }
    }
}