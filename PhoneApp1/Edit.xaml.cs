using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PhoneApp1
{
    public partial class Edit : PhoneApplicationPage
    {
        int userPrep, userWork, userRest, userCycles;
        
        public Edit()
        {
            InitializeComponent();
            userPrep = int.Parse(txtPrepare.Text);
            userWork = int.Parse(txtWork.Text);
            userRest = int.Parse(txtRest.Text);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void btnStartNew_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to Edit Timer Routine page
            NavigationService.Navigate(new Uri("/EditPageTimer.xaml", UriKind.Relative));
        }
    }
}