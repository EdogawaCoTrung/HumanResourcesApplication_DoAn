using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
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
        private DateTime _startDate;
        private DateTime _endDate;
        private string? _note;
        private List<string?> listLeaveRequest;
        public ICommand SendCommand { get; }
        public IUserRepository UserRepository { get; }
        public ICommand CancelCommand { get; }
        public ISendLeaveRequestRepository sendLeaveRequestRepository;
        public string? UserId { get => _userId; set { _userId = value; OnPropertyChanged(nameof(UserId)); } }
        public string? UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); } }
        public string? LeaveType { get => _leaveType; set { _leaveType = value; OnPropertyChanged(nameof(LeaveType)); } }
        public DateTime StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }
        public DateTime EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }
        public string? Note { get => _note; set { _note = value; OnPropertyChanged(nameof(Note)); } }

        public List<string?> ListLeaveRequest { get => listLeaveRequest; set { listLeaveRequest = value; OnPropertyChanged(nameof(ListLeaveRequest)); } }
        public ChangeDate changeDate;
        public AddLeaveRequestVM()
        {
            SendCommand = new ViewModelCommand(ExecuteLeaveCommand, CanExecuteLeaveCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            sendLeaveRequestRepository = new SendLeaveRequestRepository();
            UserRepository = new UserRepository();
            User user = UserRepository.GetByLoginName(MyApp.currentUser.loginName);
            UserId = user.userId;
            UserName = user.userName;
            changeDate = new ChangeDate();
            StartDate = DateTime.Now;
            EndDate = StartDate.AddDays(1);

            ListLeaveRequest = new List<string?>();
            ListLeaveRequest.Add("Annual Leave");
            ListLeaveRequest.Add("Sick Leave");
            ListLeaveRequest.Add("Maternity Leave");
            ListLeaveRequest.Add("Special Leave");
        }


        private void ExecuteLeaveCommand(object? obj)
        {
            string tempStartDate = changeDate.ChangeDateFormat(StartDate);
            string tempEndDate = changeDate.ChangeDateFormat(EndDate);
            sendLeaveRequestRepository.SendLeaveRequest(UserId, tempStartDate, tempEndDate, Note, LeaveType);
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
            if (StartDate == null)
                validData = false;
            if(EndDate == null)
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
