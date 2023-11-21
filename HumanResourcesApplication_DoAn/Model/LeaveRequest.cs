using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    internal class LeaveRequest
    {
        public string leaveId { get; set; }
        public string userId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string reason { get; set; }
        public string leaveType { get; set; }
    }
}
