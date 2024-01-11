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
        public ViewModelCommand AcceptCommand { get; }
        public ViewModelCommand DeleteCommand { get; }
        private List<LeaveRequest>? listLeaveRequests;
        private LeaveRequest? _selectedItem;
        private List<LeaveRequest> leaveRequestsAccepted;
        public List<LeaveRequest>? ListLeaveRequests { get => listLeaveRequests; set { listLeaveRequests = value; OnPropertyChanged(nameof(ListLeaveRequests)); } }
        public int TotalEmployee { get => _totalEmployee; set { _totalEmployee = value; OnPropertyChanged(nameof(TotalEmployee)); } }
        public int Present { get => _present; set { _present = value; OnPropertyChanged(nameof(Present)); } }
        public int Absence { get => _absence; set { _absence = value; OnPropertyChanged(nameof(Absence)); } }
        public LeaveRequest? selectedItem { get => _selectedItem; set { _selectedItem = value; OnPropertyChanged(nameof(selectedItem)); } }

        public LeaveRequestsViewModel()
        {
            leaveRequestsRepository = new ListLeaveRequestsRepository();
            ListLeaveRequests = new List<LeaveRequest>();
            listUsers = new ListUsersRepository();
            ListLeaveRequests = leaveRequestsRepository.ListLeaveRequests();
            selectedItem = new LeaveRequest();
            leaveRequestsAccepted = leaveRequestsRepository.ListLeaveRequestsAccepted();
            AcceptCommand = new ViewModelCommand(ExcuteAcceptCommand, CanExecuteAcceptCommand);
            DeleteCommand = new ViewModelCommand(ExcuteDeleteCommand, CanExecuteDeleteCommand);
            TotalEmployee = listUsers.ListUsers() != null ? listUsers.ListUsers().Count : 0;
            Absence = 0;
            Present = 0;
            List<string?> check = new List<string?>();
            for (int i = 0; i < leaveRequestsAccepted.Count; i++)
            {
                bool check2 = false;
                if(check != null)
                    for(int j = 0; j < check.Count; j++)
                    {
                        if (check[j] == leaveRequestsAccepted[i].userId)
                        {
                            check2 = true;
                        }
                    }
                if (!check2)
                    if (leaveRequestsAccepted[i].startDate <= DateOnly.FromDateTime(DateTime.Now) && leaveRequestsAccepted[i].endDate >= DateOnly.FromDateTime(DateTime.Now))
                    {
                        Absence++;
                        check.Add(leaveRequestsAccepted[i].userId);
                    }
            }
            check.Clear();
            Present = TotalEmployee - Absence;
        }
        private bool CanExecuteDeleteCommand(object? obj)
        {
            return true;
        }

        private void ExcuteDeleteCommand(object? obj)
        {
            leaveRequestsRepository.DeleteLeaveRequest(selectedItem);
            ListLeaveRequests = leaveRequestsRepository.ListLeaveRequests();
            TotalEmployee = listUsers.ListUsers() != null ? listUsers.ListUsers().Count : 0;
            Absence = 0;
            Present = 0;
            List<string?> check = new List<string?>();
            for (int i = 0; i < leaveRequestsAccepted.Count; i++)
            {
                bool check2 = false;
                if (check != null)
                    for (int j = 0; j < check.Count; j++)
                    {
                        if (check[j] == leaveRequestsAccepted[i].userId)
                        {
                            check2 = true;
                        }
                    }
                if (!check2)
                    if (leaveRequestsAccepted[i].startDate <= DateOnly.FromDateTime(DateTime.Now) && leaveRequestsAccepted[i].endDate >= DateOnly.FromDateTime(DateTime.Now))
                    {
                        Absence++;
                        check.Add(leaveRequestsAccepted[i].userId);
                    }
            }
            check.Clear();
            Present = TotalEmployee - Absence;
            MessageBox.Show("Leave Request is deleted!");
        }


        private bool CanExecuteAcceptCommand(object? obj)
        {
            return true;
        }

        private void ExcuteAcceptCommand(object? obj)
        {
            leaveRequestsRepository.AcceptLeaveRequest(selectedItem);
            ListLeaveRequests = leaveRequestsRepository.ListLeaveRequests();
            TotalEmployee = listUsers.ListUsers() != null ? listUsers.ListUsers().Count : 0;
            Absence = 0;
            Present = 0;
            List<string?> check = new List<string?>();
            for (int i = 0; i < leaveRequestsAccepted.Count; i++)
            {
                bool check2 = false;
                if (check != null)
                    for (int j = 0; j < check.Count; j++)
                    {
                        if (check[j] == leaveRequestsAccepted[i].userId)
                        {
                            check2 = true;
                        }
                    }
                if (!check2)
                    if (leaveRequestsAccepted[i].startDate <= DateOnly.FromDateTime(DateTime.Now) && leaveRequestsAccepted[i].endDate >= DateOnly.FromDateTime(DateTime.Now))
                    {
                        Absence++;
                        check.Add(leaveRequestsAccepted[i].userId);
                    }
            }
            check.Clear();
            Present = TotalEmployee - Absence;
            MessageBox.Show("Leave Request is accepted!");
        }

    }
}
