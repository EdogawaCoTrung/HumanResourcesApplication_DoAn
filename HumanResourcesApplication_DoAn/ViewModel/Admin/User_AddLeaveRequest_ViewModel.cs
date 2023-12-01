using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class User_AddLeaveRequest_ViewModel:ViewModelBase
    {
        List<string>? _listLeaveRequests;
        string? _leaveRequestType;
        string _startDate;
        string _endDate;
        string _userName;
        string _userId;
        string _note;
        private ISendLeaveRequestRepository sendLeaveRequestRepository;
       
        public string? LeaveRequestType { get => _leaveRequestType; set { _leaveRequestType = value; OnPropertyChanged(nameof(LeaveRequestType)); } }
        public string StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }
        public string EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); }}
        public string UserId { get => _userId; set { _userId = value; OnPropertyChanged(nameof(UserId)); } }
        public string Note { get => _note; set { _note = value; OnPropertyChanged(nameof(Note)); }  }
        //Command
        public List<string>? ListLeaveRequests { get => _listLeaveRequests; set { _listLeaveRequests = value; OnPropertyChanged(nameof(ListLeaveRequests)); } }
        public ViewModelCommand SendLeaveRequestCommand { get; }
        public ViewModelCommand CancelCommand { get; }
        

        public User_AddLeaveRequest_ViewModel()
        {

            ListLeaveRequests = new List<string>();
            ListLeaveRequests.Add("Annual Leave");
            ListLeaveRequests.Add("Sick Leave");
            ListLeaveRequests.Add("Maternity Leave");
            ListLeaveRequests.Add("Special Leave");
            sendLeaveRequestRepository = new SendLeaveRequestRepository();

            SendLeaveRequestCommand = new ViewModelCommand(ExcuteSendLeaveRequestCommand, CanExcuteSendLeaveRequestCommand);
            CancelCommand = new ViewModelCommand(ExcuteCancelCommand);
            
         }

        
        private void ExcuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close();
        }

        private bool CanExcuteSendLeaveRequestCommand(object? obj)
        {
            bool validData = true;
            if (UserId == null || UserId == "")
                validData = false;
            if (UserName == null || UserName == "")
                validData = false;
            if (LeaveRequestType == null)
                validData = false;
            if (StartDate == null || StartDate == "")
                validData = false;
            if (EndDate == null || EndDate == "")
                validData = false;
            return validData;
        }

        private void ExcuteSendLeaveRequestCommand(object? obj)
        {
            sendLeaveRequestRepository.SendLeaveRequest(UserId, StartDate, EndDate, Note, LeaveRequestType);
            Application.Current.MainWindow.Close();
        }
    }
}
