using HumanResourcesApplication_DoAn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class User_AddLeaveRequest_ViewModel:ViewModelBase
    {
        List<LeaveRequest>? _listLeaveRequests;
        string? _leaveRequestType;
        string _startDate;
        string _endDate;
        string _userName;
        string _userId;
        string _note;


       
        public string? LeaveRequestType { get => _leaveRequestType; set { _leaveRequestType = value; OnPropertyChanged(nameof(LeaveRequestType)); } }
        public string StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }
        public string EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); }}
        public string UserId { get => _userId; set { _userId = value; OnPropertyChanged(nameof(UserId)); } }
        public string Note { get => _note; set { _note = value; OnPropertyChanged(nameof(Note)); }  }
        //Command
        public ViewModelCommand SendLeaveRequestCommand { get; }
        public ViewModelCommand CancelCommand { get; }
        public User_AddLeaveRequest_ViewModel()
        {
            SendLeaveRequestCommand = new ViewModelCommand(ExcuteSendLeaveRequestCommand, CanExcuteSendLeaveRequestCommand);
            CancelCommand = new ViewModelCommand(ExcuteCancelCommand);
        }

        
        private void ExcuteCancelCommand(object? obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExcuteSendLeaveRequestCommand(object? obj)
        {
            return true;
        }

        private void ExcuteSendLeaveRequestCommand(object? obj)
        {
           
        }
    }
}
