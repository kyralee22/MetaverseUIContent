using MetaverseUIContentWinUI;
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
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MetaverseUIContent.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page, SubPage
    {
        public string header => "Home";
        MainWindow navBar = (MainWindow)(Application.Current as App).m_window;
        public HomePage()
        {
            this.InitializeComponent();
            
        }
        private void ShowTip(object sender, RoutedEventArgs e)
        {
            ToggleThemeTeachingTip1.IsOpen = true;
        }

        public void SwitchToHowTo(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HowToUsePage));
            navBar.setSelected("HowToUse_Item");
        }
        
        public void SwitchToButton(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ButtonPage));
            navBar.setSelected("Button_Item");
        }
        public void SwitchToCheckbox(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CheckboxPage));
            navBar.setSelected("Checkbox_Item");
        }
        public void SwitchToDropdown(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DropdownPage));
            navBar.setSelected("Dropdown_Item");
        }
        public void SwitchToFlipView(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FlipViewPage));
            navBar.setSelected("FlipView_Item");
        }
        public void SwitchToTeachingTip(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TeachingTipPage));
            navBar.setSelected("TeachingTip_Item");
        }
        public void SwitchToFonts(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FontsPage));
            navBar.setSelected("Fonts_Item");
        }
        public void SwitchToNumberBox(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NumberBoxPage));
            navBar.setSelected("NumberBox_Item");
        }
        public void SwitchToSlider(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SliderPage));
            navBar.setSelected("Slider_Item");
        }
        public void SwitchToTextBox(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TextBoxPage));
            navBar.setSelected("TextBox_Item");
        }
        public void SwitchToToggle(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TogglePage));
            navBar.setSelected("Toggle_Item");
        }
        public void optionClick(object sender, RoutedEventArgs e)
        {
            DropDownButton d = (DropDownButton)FindName("dropdownButton");
            MenuFlyoutItem m = (MenuFlyoutItem)sender;
            d.Content = m.Text;
        }

    }
}
