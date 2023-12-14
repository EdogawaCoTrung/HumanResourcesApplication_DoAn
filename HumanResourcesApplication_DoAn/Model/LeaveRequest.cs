using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class LeaveRequest
    {
        public string? leaveId { get; set; }
        public string? userId { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
        public string? reason { get; set; }
        public string? leaveType { get; set; }
        public bool? isAccepted { get; set; }
        public virtual User? User { get; set; }

        public LeaveRequest()
        {
            User = new User();
        }
    }
}
