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

        TimeSpan prepDuration = new TimeSpan(0, 0, 0, 10);
        TimeSpan workDuration = new TimeSpan(0, 0, 0, 20);
        TimeSpan restDuration = new TimeSpan(0, 0, 0, 10);

        public Edit()
        {
            InitializeComponent();

            txtblEditPrepare.Text = prepDuration.ToString(@"mm\:ss");
            txtblEditWork.Text = workDuration.ToString(@"mm\:ss");
            txtblEditRest.Text = restDuration.ToString(@"mm\:ss"); 
            
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