using HumanResourcesApplication_DoAn.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace HumanResourcesApplication_DoAn.Utils
{
    public class Timer
    {
        public void Setter()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 10000;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            LeaveRequestsViewModel leaveRequestsViewModel = new LeaveRequestsViewModel();
        }
    }
}
