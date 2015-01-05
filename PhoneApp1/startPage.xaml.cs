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
        
       DispatcherTimer timer;
       
       TimeSpan prepInterval = new TimeSpan(0, 0, 10);
       TimeSpan workInterval = new TimeSpan(0, 0, 20);
       TimeSpan restInterval = new TimeSpan(0, 0, 10);

       Stopwatch timerWatch = new Stopwatch();

       private TrainingState state = TrainingState.Stopped;
       private int roundNum;

        public startPage()
        {
            InitializeComponent();
            hour = 0;
            minute = 0;
            second = 0;
            milllisecond = 0;
            roundNum = 1;            
        }

        public enum TrainingState
        {
            Stopped, 
            Preparing, 
            Working,
            Resting
        }

        private void btnBegin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            timerWatch.Start();    
            timer = new DispatcherTimer();           
            timer.Interval = new TimeSpan(0, 0, 1);            
            timer.Tick += timer_Tick;
            timer.Start();    

            btnPause.Visibility = System.Windows.Visibility.Visible;               
                       
        }//end of btnBegin             

        private void timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ChangeState();                    
        }

        private void ChangeState()
        {
            switch (state)
            {
                case TrainingState.Stopped:
                    {                           
                        timer.Interval = prepInterval;                   

                        milllisecond = timerWatch.ElapsedMilliseconds;
                        second = milllisecond / 1000;
                        milllisecond = milllisecond % 1000;
                        minute = second / 60;
                        second = second % 60;
                        hour = minute / 60;
                        minute = minute % 60;
                        txtblTime.Text = minute.ToString("00") + ":" + second.ToString("00");              
                                          
                        state = TrainingState.Preparing;
                    }
                    break;

                case TrainingState.Preparing:
                    {                        
                        timer.Interval = workInterval;
                        
                        timerWatch.Restart();

                        milllisecond = timerWatch.ElapsedMilliseconds;
                        second = milllisecond / 1000;
                        milllisecond = milllisecond % 1000;
                        minute = second / 60;
                        second = second % 60;
                        hour = minute / 60;
                        minute = minute % 60;
                        txtblTime.Text = minute.ToString("00") + ":" + second.ToString("00");
                        
                        txtblPrepare.Text = "Work!";

                        state = TrainingState.Working;
                    }
                    break;

                case TrainingState.Working:
                    {
                        timer.Interval = restInterval;

                        timerWatch.Restart();

                        milllisecond = timerWatch.ElapsedMilliseconds;
                        second = milllisecond / 1000;
                        milllisecond = milllisecond % 1000;
                        minute = second / 60;
                        second = second % 60;
                        hour = minute / 60;
                        minute = minute % 60;
                        txtblTime.Text = minute.ToString("00") + ":" + second.ToString("00");

                        txtblPrepare.Text = "Rest!";

                        state = TrainingState.Resting;
                    }
                    break;

                case TrainingState.Resting:
                    {
                        if (roundNum != 8)
                        {
                            roundNum++;
                            state = TrainingState.Preparing;
                            txtblRoundNo.Text = roundNum.ToString();
                        }
                        else
                        {
                            timer.Stop();
                            txtblTime.Text = "Times Up!";
                        }
                    }
                    break;
            }
        }

        //private void timer_calculation()
        //{
        //    milllisecond = timerWatch.ElapsedMilliseconds;
        //    second = milllisecond / 1000;
        //    milllisecond = milllisecond % 1000;
        //    minute = second / 60;
        //    second = second % 60;
        //    hour = minute / 60;
        //    minute = minute % 60;
        //    txtblTime.Text = minute.ToString("00") + ":" + second.ToString("00");
        //}
   
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