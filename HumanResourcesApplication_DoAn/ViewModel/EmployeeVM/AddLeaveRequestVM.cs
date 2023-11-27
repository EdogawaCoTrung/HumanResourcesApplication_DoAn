using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class AddLeaveRequestVM : ViewModelBase
    {
        private string? _userId;
        private string? _userName;
        private string? _leaveType;
        private string? _startDate;
        private string? _endDate;
        private string? _note;
        private List<string?> listLeaveRequest;
        public ICommand SendCommand { get; }
        public ICommand CancelCommand { get; }
        public ISendLeaveRequestRepository sendLeaveRequestRepository;
        public string? UserId { get => _userId; set { _userId = value; OnPropertyChanged(nameof(UserId)); } }
        public string? UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); } }
        public string? LeaveType { get => _leaveType; set { _leaveType = value; OnPropertyChanged(nameof(LeaveType)); } }
        public string? StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }
        public string? EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }
        public string? Note { get => _note; set { _note = value; OnPropertyChanged(nameof(Note)); } }

        public List<string?> ListLeaveRequest { get => listLeaveRequest; set { listLeaveRequest = value; OnPropertyChanged(nameof(ListLeaveRequest)); } }

        public AddLeaveRequestVM()
        {
            SendCommand = new ViewModelCommand(ExecuteLeaveCommand, CanExecuteLeaveCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            sendLeaveRequestRepository = new SendLeaveRequestRepository();
            ListLeaveRequest = new List<string?>();
            ListLeaveRequest.Add("Annual Leave");
            ListLeaveRequest.Add("Sick Leave");
            ListLeaveRequest.Add("Maternity Leave");
            ListLeaveRequest.Add("Special Leave");
        }


        private void ExecuteLeaveCommand(object? obj)
        {
            sendLeaveRequestRepository.SendLeaveRequest(UserId, StartDate, EndDate, Note, LeaveType);
            Application.Current.MainWindow.Close();
        }
        private bool CanExecuteLeaveCommand(object? obj)
        {
            bool validData = true;
            if(UserId == null || UserId=="")
                validData = false;
            if(UserName == null || UserName=="")
                validData = false;
            if (LeaveType == null)
                validData = false;
            if (StartDate == null || StartDate == "" )
                validData = false;
            if(EndDate == null || EndDate == "")
                validData = false;
            return validData;
        }
        private void ExecuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close();
        }

        private bool CanExecuteCancelCommand(object? obj)
        {
            return true;
        }

    }
}
