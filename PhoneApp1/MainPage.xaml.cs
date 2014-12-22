using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnStart_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //Navigate to Routine page
            NavigationService.Navigate(new Uri("/startPage.xaml", UriKind.Relative));
        }
      

        private void btnOneDrive_Click(object sender, RoutedEventArgs e)
        {
            ShowInBrowser("https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=12&ct=1396013362&rver=6.4.6456.0&wp=MBI_SSL_SHARED&wreply=https:%2F%2Fonedrive.live.com%2F%3Fgologin%3D1%26mkt%3Den-GB&lc=2057&id=250206&cbcxt=sky&mkt=en-GB&cbcxt=sky");
        }

        private void ShowInBrowser(string url)
        {
            Microsoft.Phone.Tasks.WebBrowserTask wbt = new Microsoft.Phone.Tasks.WebBrowserTask();
            wbt.Uri = new Uri(url);
            wbt.Show();
            throw new NotImplementedException();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to Edit Routine page
            NavigationService.Navigate(new Uri("/Edit.xaml", UriKind.Relative));
        }
      

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}