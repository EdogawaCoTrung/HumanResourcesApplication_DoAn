using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface ISendLeaveRequestRepository
    {
        void SendLeaveRequest(string? userId, string? startDate, string? endDate, string? reason, string? leaveType);
    }
}
