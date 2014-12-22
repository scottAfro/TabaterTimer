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
       int i, endPrep, endRound, rounds, counter;

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
            //rounds = 8;
            counter = 0;
        }

        private void btnBegin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
            if(btnBegin.Content.ToString() == "Begin")
            {
                //timerWatch.Start();
                //timer = new DispatcherTimer();
                //timer.Interval = new TimeSpan(0, 0, 0, 1, 0);       
                //timer.Tick += timer_Tick;
                //timer.Start();
                //btnPause.Visibility = System.Windows.Visibility.Visible;

                //Need to start a counter for each round(8)
                for (rounds = 0; rounds < 9; rounds++) // or if()if the timer = 10 seconds + rounds < 9                
                {
                    timerWatch.Start();
                    timer = new DispatcherTimer();
                    timer.Interval = new TimeSpan(0, 0, 0, 1, 0);                   
                    timer.Tick += timer_Tick;
                    timer.Start();
                    btnPause.Visibility = System.Windows.Visibility.Visible;
                    counter = rounds;
                    txtblRoundNo.Text = counter.ToString();
                }
            }
            else
            {
                 timerWatch.Stop();
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
            //timerWatch.Stop();
            //txtblTime.Text = minute.ToString("00") + ":" + second.ToString("00");
            timerWatch.Restart();
            timerWatch.Stop();

        }
    }
}