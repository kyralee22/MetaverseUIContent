using MetaverseUIContentWinUI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MetaverseUIContent.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    
    public sealed partial class CheckboxPage : Page, SubPage
    {
        public string header => "Checkbox";
        private MainWindow wnd = (MainWindow)(Application.Current as App).m_window;
        public CheckboxPage()
        {
            this.InitializeComponent();
        }

        public void navHowTo(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HowToUsePage));
            wnd.setSelected("HowToUse_Item");
        }

        public void navFonts(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FontsPage));
            wnd.setSelected("Fonts_Item");
        }

        public void checkboxDownload(object sender, RoutedEventArgs e)
        {
            wnd.pickDownloadLocation("ms-appx:///Assets/Unity Assets/Checkbox.unitypackage", "CheckboxAsset.unitypackage");
        }
    }
}
