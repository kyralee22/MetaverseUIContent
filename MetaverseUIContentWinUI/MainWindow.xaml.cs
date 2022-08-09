using MetaverseUIContent.Views;
using Microsoft.UI;
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
using System.Windows;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.Storage.Pickers;
using WinRT.Interop;
using Windows.Storage;
using Windows.UI.Core;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MetaverseUIContentWinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Title = "Metaverse UI Content";
        }

        #region NavigationView event handlers
        private void NavBar_Loaded(object sender, RoutedEventArgs e)
        {
            // set Home as default selected item
            foreach (NavigationViewItemBase item in NavBar.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Home_Page")
                {
                    NavBar.SelectedItem = item;
                    break;
                }
            }
            contentFrame.Navigate(typeof(HomePage));
        }
        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            TryGoBack();
        }

        private void CoreDispatcher_AcceleratorKeyActivated(CoreDispatcher sender, AcceleratorKeyEventArgs e)
        {
            // When Alt+Left are pressed navigate back
            if (e.EventType == CoreAcceleratorKeyEventType.SystemKeyDown
                && e.VirtualKey == VirtualKey.Left
                && e.KeyStatus.IsMenuKeyDown == true
                && !e.Handled)
            {
                e.Handled = TryGoBack();
            }
        }

        private void System_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = TryGoBack();
            }
        }

        private void CoreWindow_PointerPressed(CoreWindow sender, PointerEventArgs e)
        {
            // Handle mouse back button.
            if (e.CurrentPoint.Properties.IsXButton1Pressed)
            {
                e.Handled = TryGoBack();
            }
        }

        private bool TryGoBack()
        {
            if (!contentFrame.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed.
            if (NavBar.IsPaneOpen &&
                (NavBar.DisplayMode == NavigationViewDisplayMode.Compact ||
                 NavBar.DisplayMode == NavigationViewDisplayMode.Minimal))
                return false;

            contentFrame.GoBack();
            return true;
        }

        private void NavBar_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
        }

        public void NavBar_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            
            TextBlock ItemContent = args.InvokedItem as TextBlock;
            if (ItemContent != null)
            {
                NavBar_Navigate(ItemContent.Tag);
            }
        }

        public void setSelected(string item)
        {
            NavBar.SelectedItem = NavBar.FindName(item) as NavigationViewItem;
        }

        public void NavBar_Navigate(object tag)
        {
            switch (tag)
            {
                case "Nav_Home": contentFrame.Navigate(typeof(HomePage)); break;
                case "Nav_HowToUse": contentFrame.Navigate(typeof(HowToUsePage)); break;
                case "Nav_Button": contentFrame.Navigate(typeof(ButtonPage)); break;
                case "Nav_Checkbox": contentFrame.Navigate(typeof(CheckboxPage)); break;
                case "Nav_Dropdown": contentFrame.Navigate(typeof(DropdownPage)); break;
                case "Nav_FlipView": contentFrame.Navigate(typeof(FlipViewPage)); break;
                case "Nav_TeachingTip": contentFrame.Navigate(typeof(TeachingTipPage)); break;
                case "Nav_Fonts": contentFrame.Navigate(typeof(FontsPage)); break;
                case "Nav_NumberBox": contentFrame.Navigate(typeof(NumberBoxPage)); break;
                case "Nav_Slider": contentFrame.Navigate(typeof(SliderPage)); break;
                case "Nav_TextBox": contentFrame.Navigate(typeof(TextBoxPage)); break;
                case "Nav_Toggle": contentFrame.Navigate(typeof(TogglePage)); break;
            }
        }
        #endregion

        private void contentFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        public async void pickDownloadLocation(string fileLocation, string fileName)
        {
            var folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Downloads;
            folderPicker.FileTypeFilter.Add("*");

            var hwnd = WindowNative.GetWindowHandle((Application.Current as App).m_window);
            InitializeWithWindow.Initialize(folderPicker, hwnd);

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();

            StorageFile buttonFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(fileLocation));
            if (folder != null)
            {
                StorageFile copiedFile = await buttonFile.CopyAsync(folder, fileName, NameCollisionOption.ReplaceExisting);
            }
        }
    }
}
