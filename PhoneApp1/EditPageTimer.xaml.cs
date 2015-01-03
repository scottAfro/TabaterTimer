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
            num = 0;
        }

        private void btnEditBegin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var obj = App.Current as App;
            string abc = obj.userPrep;
            num = Convert.ToInt32(abc);

            editWatch.Start();
            editTimer = new DispatcherTimer();
            editTimer.Interval = new TimeSpan(0, 0, 1, 0);
            editTimer.Tick += editTimer_Tick;
            editTimer.Start();            
        }

        void editTimer_Tick(object sender, EventArgs e)
        {
            num--;

            if(num == 0)
            {
                editTimer.Stop();
                txtblEditTime.Text = num + " Seconds";
            }



            //if (TimeSpan.TryParseExact(abc, "%s", null, out userInterval))
            //{           
            //    edMilllisecond = editWatch.ElapsedMilliseconds;
            //    edSecond = edMilllisecond / 1000;
            //    edMilllisecond = edMilllisecond % 1000;
            //    edMinute = edSecond / 60;
            //    edSecond = edSecond % 60;
            //    edHour = edMinute / 60;
            //    edMinute = edMinute % 60;
            //    txtblEditTime.Text = edMinute.ToString("00") + ":" + edSecond.ToString("00");
            //    //throw new NotImplementedException();
            //}
            //else
            //    txtblEditTime.Text = "Times Up! ";        
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