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
    public partial class startPage : PhoneApplicationPage
    {
       Stopwatch timerWatch = new Stopwatch();

       long hour, minute, second, milllisecond;
       int i, endPrep, endRound, rounds;

       DispatcherTimer timer;      

        public startPage()
        {
            InitializeComponent();
            hour = 0;
            minute = 0;
            second = 0;
            milllisecond = 0;
            endPrep = 10;
            endRound = 20;
            rounds = 9;            
        }

        private void btnBegin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {            
            //Need to start a counter for each round(8)
            for (i = 0; i < rounds; i++)               
            {
                timerWatch.Start();
                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
                timer.Tick += timer_Tick;
                timer.Start();
                btnPause.Visibility = System.Windows.Visibility.Visible;
                txtblPrepare.Visibility = System.Windows.Visibility.Collapsed;
                txtblGo.Visibility = System.Windows.Visibility.Visible;
                txtblRoundNo.Text = i.ToString();
            }         
        }//end of btnBegin

        private void timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            milllisecond = timerWatch.ElapsedMilliseconds;

            second = milllisecond / 1000;
            milllisecond = milllisecond % 1000;

            minute = second / 60;
            second = second % 60;

            hour = minute / 60;
            minute = minute % 60;

            txtblTime.Text = minute.ToString("00") + ":" + second.ToString("00");           
        }
   
        private void btnStop_Tap(object sender, System.Windows.Input.GestureEventArgs e)//actually the pause button
        {
            if (timer != null)
            {
                timerWatch.Stop();
            }
        }

        private void btnPause_Tap(object sender, System.Windows.Input.GestureEventArgs e)//actually the stop button
        {
            //set back to 00:00
            timerWatch.Restart();
            timerWatch.Stop();
            txtblPrepare.Visibility = System.Windows.Visibility.Visible;
            txtblGo.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}