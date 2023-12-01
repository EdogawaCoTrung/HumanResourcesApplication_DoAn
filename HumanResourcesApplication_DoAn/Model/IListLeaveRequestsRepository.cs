using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IListLeaveRequestsRepository
    {
        List<LeaveRequest> ListLeaveRequests();
        List<LeaveRequest> ListLeaveRequestsAccepted();
        void AcceptLeaveRequest(LeaveRequest selectedItem);
        void DeleteLeaveRequest(LeaveRequest selectedItem);
    }
}
