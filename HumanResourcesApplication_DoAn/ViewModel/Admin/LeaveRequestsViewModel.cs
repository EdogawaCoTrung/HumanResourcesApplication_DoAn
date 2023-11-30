using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            ListLeaveRequests = leaveRequestsRepository.ListLeaveRequests();
            TotalEmployee = listUsers.ListUsers() != null ? listUsers.ListUsers().Count : 0;
            Absence = 0;
            Present = 0;
            List<string?> check = new List<string?>();
            for (int i = 0; i < ListLeaveRequests.Count; i++)
            {
                bool check2 = false;
                if(check != null)
                    for(int j = 0; j < check.Count; j++)
                    {
                        if (check[j] == ListLeaveRequests[i].userId)
                        {
                            check2 = true;
                        }
                    }
                if (!check2)
                    if (ListLeaveRequests[i].startDate <= DateOnly.FromDateTime(DateTime.Now) && ListLeaveRequests[i].endDate >= DateOnly.FromDateTime(DateTime.Now))
                    {
                        Absence++;
                        check.Add(ListLeaveRequests[i].userId);
                    }
            }
            check.Clear();
            Present = TotalEmployee - Absence;
            AcceptCommand = new ViewModelCommand(ExcuteAcceptCommand);
        }
        public ViewModelCommand AcceptCommand { get; }
        private void ExcuteAcceptCommand(object? obj)
        {
            MessageBox.Show("Hi");
        }

    }
}
