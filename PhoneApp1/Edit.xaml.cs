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
        
        public Edit()
        {
            InitializeComponent();           
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //base.OnNavigatedFrom(e);
            EditPageTimer userInput = e.Content as EditPageTimer;
            if(userInput != null)
            {
                userInput.userPrep = txtPrepare.Text;
                userInput.userWork = txtWork.Text;
                userInput.userRest = txtRest.Text;
            }
            
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
        }

        private void btnStartNew_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to Edit Timer Routine page
           // var obj = App.Current as App;
           // obj.userPrep = txtPrepare.Text;
           // obj.userWork = txtWork.Text;
           // obj.userRest = txtRest.Text;
            this.NavigationService.Navigate(new Uri("/EditPageTimer.xaml", UriKind.Relative));
        }
    }
}

// if(userPrep > 0)
// {
//     userPrep--;
//     txtblTime.Text = userPrep + " Seconds Remaining";
// }                             
//else if (userWork < 1 )
//{
//    userWork--;
//    txtblTime.Text = userWork + " Seconds Remaining";
//    txtblPrepare.Visibility = System.Windows.Visibility.Collapsed;
//    txtblGo.Visibility = System.Windows.Visibility.Visible;
//}
//else if (userRest < 1)
//{
//    userRest--;
//    txtblTime.Text = userRest + " Seconds Remaining";
//    txtblGo.Visibility = System.Windows.Visibility.Collapsed;
//    txtblRest.Visibility = System.Windows.Visibility.Visible;
//}    