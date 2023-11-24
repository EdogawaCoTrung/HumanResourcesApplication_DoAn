using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class LeaveRequestsViewModel : ViewModelBase
    {
        private IListLeaveRequestsRepository? leaveRequestsRepository;
        private List<LeaveRequest>? listLeaveRequests;
        public List<LeaveRequest>? ListLeaveRequests { get => listLeaveRequests; set { listLeaveRequests = value; OnPropertyChanged(nameof(ListLeaveRequests)); } }

        public LeaveRequestsViewModel()
        {
            leaveRequestsRepository = new LeaveRequestsRepository();
            ListLeaveRequests = new List<LeaveRequest>();
            ListLeaveRequests = leaveRequestsRepository.ListLeaveRequests();
        }
    }
}
