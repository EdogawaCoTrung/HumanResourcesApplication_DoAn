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
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string? reason { get; set; }
        public string? leaveType { get; set; }
        public virtual User? User { get; set; }

        public LeaveRequest()
        {
            User = new User();
        }
    }
}
