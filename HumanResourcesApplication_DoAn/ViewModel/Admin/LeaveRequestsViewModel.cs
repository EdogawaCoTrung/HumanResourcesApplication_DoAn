using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class LeaveRequestsViewModel : ViewModelBase
    {
        private int _totalEmployee;
        private int _present;
        private int _absence;
        private IListLeaveRequestsRepository? leaveRequestsRepository;
        private IListUsersRepository? listUsers;
        private List<LeaveRequest>? listLeaveRequests;
        public List<LeaveRequest>? ListLeaveRequests { get => listLeaveRequests; set { listLeaveRequests = value; OnPropertyChanged(nameof(ListLeaveRequests)); } }
        public int TotalEmployee { get => _totalEmployee; set { _totalEmployee = value; OnPropertyChanged(nameof(TotalEmployee)); } }
        public int Present { get => _present; set { _present = value; OnPropertyChanged(nameof(Present)); } }
        public int Absence { get => _absence; set { _absence = value; OnPropertyChanged(nameof(Absence)); } }

        public LeaveRequestsViewModel()
        {
            leaveRequestsRepository = new ListLeaveRequestsRepository();
            ListLeaveRequests = new List<LeaveRequest>();
            listUsers = new ListUsersRepository();
            Timer timer = new Timer();
            ListLeaveRequests = leaveRequestsRepository.ListLeaveRequests();
            TotalEmployee = listUsers.ListUsers() != null ? listUsers.ListUsers().Count : 0;
            Absence = 0;
            Present = 0;
            List<string?> check = new List<string?>();
            for (int i = 0; i < ListLeaveRequests.Count; i++)
            {
                if (ListLeaveRequests[i].startDate <= DateOnly.FromDateTime(DateTime.Now) && ListLeaveRequests[i].endDate >= DateOnly.FromDateTime(DateTime.Now))
                {
                    Absence++;
                }
            }
            check.Clear();
            Present = TotalEmployee - Absence;
            timer.Setter();
        }
    }
}
