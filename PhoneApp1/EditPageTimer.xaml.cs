using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using System.Diagnostics;

namespace PhoneApp1
{
    public partial class EditPageTimer : PhoneApplicationPage
    {
        public string userPrep { get; set; }
        public string userWork { get; set; }
        public string userRest { get; set; }
        public int userCycles { get; set; }

        long edHour, edMinute, edSecond, edMilllisecond;
        DispatcherTimer editTimer;
        TimeSpan userInterval;
        Stopwatch editWatch = new Stopwatch();
        int num;

        public EditPageTimer()
        {
            InitializeComponent();
            edHour = 0;
            edMinute = 0;
            edSecond = 0;
            edMilllisecond = 0;
             
        }

        private void EditPageTimerPage_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnEditBegin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {     
            //editWatch.Start();            
            editTimer = new DispatcherTimer();
            editTimer.Interval = new TimeSpan(0, 0, 1, 0);
            editTimer.Tick += editTimer_Tick;
            editTimer.Start();
            btnEditPause.Visibility = System.Windows.Visibility.Visible;

            num = Convert.ToInt32(this.userPrep);      
            txtblEditTime.Text = num + " Seconds";     
        }

        private void editTimer_Tick(object sender, EventArgs e)
        {
            num--;

            if(num == 0)
            {
                editTimer.Stop();
                txtblEditTime.Text = num + " Seconds";
            }
            else
            {
                txtblEditTime.Text = "Times up";
            }          
        }

        private void btnEditPause_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            editWatch.Stop();
        }

        private void btnEditStop_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            editWatch.Restart();
            editWatch.Stop();
        }
    }
}