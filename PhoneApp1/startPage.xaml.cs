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
       int i, rounds, prepTicks, workTick, restTicks;

       DispatcherTimer timer;
       Stopwatch timerWatch = new Stopwatch(); 

        public startPage()
        {
            InitializeComponent();
            hour = 0;
            minute = 0;
            second = 0;
            milllisecond = 0;            
            rounds = 1;
            prepTicks = 05;
            workTick = 20;
            restTicks = 10;
        }

        private void btnBegin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //timerWatch.Start();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.Tick += timer_Tick;
            timer.Start();
            btnPause.Visibility = System.Windows.Visibility.Visible;        

               
        }//end of btnBegin

        private void timer_Tick(object sender, EventArgs e)
        {
            ////throw new NotImplementedException();
            //milllisecond = timerWatch.ElapsedMilliseconds;

            //second = milllisecond / 1000;
            //milllisecond = milllisecond % 1000;

            //minute = second / 60;
            //second = second % 60;

            //hour = minute / 60;
            //minute = minute % 60;

            //txtblTime.Text = minute.ToString("00") + ":" + second.ToString("00");  
            //while (rounds > 0 && rounds < 9)
            //{
                if (prepTicks > 0)
                {
                    txtblPrepare.Visibility = System.Windows.Visibility.Visible;
                    txtblGo.Visibility = System.Windows.Visibility.Collapsed;
                    txtblTime.Text = prepTicks + " Seconds Remaining";
                    prepTicks--;
                }
                else if (workTick > 0)
                {
                    txtblPrepare.Visibility = System.Windows.Visibility.Collapsed;
                    txtblGo.Visibility = System.Windows.Visibility.Visible;
                    txtblTime.Text = workTick + " Seconds Remaining";
                    workTick--;
                }
                else if (restTicks > 0)
                {
                    txtblGo.Visibility = System.Windows.Visibility.Collapsed;
                    txtblRest.Visibility = System.Windows.Visibility.Visible;
                    txtblTime.Text = restTicks + " Seconds Remaining";
                    restTicks--;
                }
                else
                {
                    txtblRest.Text = "Congratulations";
                    txtblTime.Text = "Times Up";
                }
            //    rounds++;
                
            //}
            //txtblRoundNo.Text = rounds.ToString();
            
        }
   
        private void btnStop_Tap(object sender, System.Windows.Input.GestureEventArgs e)//actually the pause button
        {
            //if (prepTicks != null || workTick != null || restTicks != null)
            //{
            //    timerWatch.Stop();
            //}
        }

        private void btnPause_Tap(object sender, System.Windows.Input.GestureEventArgs e)//actually the stop button
        {
            //set back to 00:00
            
            txtblPrepare.Visibility = System.Windows.Visibility.Visible;
            txtblGo.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}