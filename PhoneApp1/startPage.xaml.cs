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
       long hour, minute, second, milllisecond;
       int rounds;

       DispatcherTimer timer;
       TimeSpan endInterval = new TimeSpan(0, 0, 5);
       TimeSpan otherInterval = new TimeSpan(0,0,20);


       Stopwatch timerWatch = new Stopwatch(); 

        public startPage()
        {
            InitializeComponent();
            hour = 0;
            minute = 0;
            second = 0;
            milllisecond = 0;            
            rounds = 1;            
        }

        private void btnBegin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            timerWatch.Start();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.Tick += timer_Tick;
            timer.Start();

           btnPause.Visibility = System.Windows.Visibility.Visible;         
            
                       
        }//end of btnBegin

        private void timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //timer timespan is more than zero, start stopwatch(get the prepare counter going)
           if (timerWatch.Elapsed < new TimeSpan(0,0,5))
            {
                milllisecond = timerWatch.ElapsedMilliseconds;
                second = milllisecond / 1000;
                milllisecond = milllisecond % 1000;
                minute = second / 60;
                second = second % 60;
                hour = minute / 60;
                minute = minute % 60;
                txtblTime.Text = minute.ToString("00") + ":" + second.ToString("00");
            }
           else if (timerWatch.Elapsed < new TimeSpan(0, 0, 20))//get the workout counter going, 
            {
                timerWatch.Restart();
                milllisecond = timerWatch.ElapsedMilliseconds;
                second = milllisecond / 1000;
                milllisecond = milllisecond % 1000;
                minute = second / 60;
                second = second % 60;
                hour = minute / 60;
                minute = minute % 60;
                txtblTime.Text = minute.ToString("00") + ":" + second.ToString("00");
                txtblPrepare.Visibility = System.Windows.Visibility.Collapsed;
                txtblGo.Visibility = System.Windows.Visibility.Visible;
            }
            else if (timerWatch.Elapsed < new TimeSpan(0, 0, 10))
            {
                timerWatch.Restart();
                milllisecond = timerWatch.ElapsedMilliseconds;
                second = milllisecond / 1000;
                milllisecond = milllisecond % 1000;
                minute = second / 60;
                second = second % 60;
                hour = minute / 60;
                minute = minute % 60;
                txtblTime.Text = minute.ToString("00") + ":" + second.ToString("00");
                txtblGo.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
                txtblTime.Text = "Times Up!";                    
        }
   
        private void btnStop_Tap(object sender, System.Windows.Input.GestureEventArgs e)//actually the pause button
        {
           timerWatch.Stop();            
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