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


       
        public string? LeaveRequestType { get => _leaveRequestType; set => _leaveRequestType = value; }
        public string StartDate { get => _startDate; set => _startDate = value; }
        public string EndDate { get => _endDate; set => _endDate = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string UserId { get => _userId; set => _userId = value; }
        public string Note { get => _note; set => _note = value; }
        //Command
        public ViewModelCommand SendLeaveRequestCommand { get; }
        public ViewModelCommand CancelCommand { get; }
        public User_AddLeaveRequest_ViewModel()
        {
        }
    }
}
