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
        public string userRounds{ get; set; }

        long edHour, edMinute, edSecond, edMilllisecond;
        DispatcherTimer editTimer;
        TimeSpan userInterval;
        Stopwatch editWatch = new Stopwatch();
        int prepNum, workNum, restNum, roundNum, round;

        public EditPageTimer()
        {
            InitializeComponent();
            edHour = 0;
            edMinute = 0;
            edSecond = 0;
            edMilllisecond = 0;
            round = 1;
        }

        private void btnEditBegin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {     
            //editWatch.Start();            
            editTimer = new DispatcherTimer();
            editTimer.Interval = new TimeSpan(0, 0, 1);
            editTimer.Tick += editTimer_Tick;
            editTimer.Start();
            btnEditPause.Visibility = System.Windows.Visibility.Visible;

            prepNum = Convert.ToInt32(this.userPrep);
            workNum = Convert.ToInt32(this.userWork);
            restNum = Convert.ToInt32(this.userRest);
            roundNum = Convert.ToInt32(this.userRounds);   
            txtblEditTime.Text = this.prepNum + " Seconds";  
        }

        private void editTimer_Tick(object sender, EventArgs e)
        {
            if(prepNum == 0)
            {   
                prepNum--;             
                txtblEditTime.Text = prepNum + " Seconds";
            }
            else if(workNum == 0)
            {
                workNum--;
                txtblEditTime.Text = workNum + " Seconds";
            }
            else if (restNum == 0)
            {
                restNum--;
                txtblEditTime.Text = restNum + " Seconds";
                //timerLoop();
            }   
            else 
            {
                editTimer.Stop();
                txtblEditTime.Text = "Times up";
            }   
        }

        //private void timerLoop()
        //{
        //    for(round = 0; round != roundNum; round++)
        //    {

        //    }
        //}

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