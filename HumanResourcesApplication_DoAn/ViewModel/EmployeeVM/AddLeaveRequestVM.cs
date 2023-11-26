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
        private List<String> _listLeaveReason;

        public AddLeaveRequestVM(List<string> listLeaveReason)
        {
            ListLeaveReason = listLeaveReason;
        }

        public ICommand SendCommand { get; }
        public string? UserId { get => _userId; set { _userId = value; OnPropertyChanged(nameof(UserId)); } }
        public string? UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); } }
        public string? LeaveType { get => _leaveType; set { _leaveType = value; OnPropertyChanged(nameof(LeaveType)); } }
        public string? StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }
        public string? EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }
        public string? Note { get => _note; set { _note = value; OnPropertyChanged(nameof(Note)); } }

        public List<string> ListLeaveReason { 
            get => _listLeaveReason; 
            set
            {
                _listLeaveReason = value;
                OnPropertyChanged(nameof(ListLeaveReason));
            }
        }

        public AddLeaveRequestVM()
        {
            SendCommand = new ViewModelCommand(ExecuteLeaveCommand, CanExecuteLeaveCommand);
            ListLeaveReason = new List<string>() {"abc","def","ghj","klm"};

        }

        private void ExecuteLeaveCommand(object? obj)
        {
            MessageBox.Show(Note);
        }
        private bool CanExecuteLeaveCommand(object? obj)
        {
            bool validData = true;
            if(UserId == null || UserId=="")
                validData = false;
            if(UserName == null || UserName=="")
                validData = false;
            //if (LeaveType == null)
            //    validData = false;
            if(StartDate == null || StartDate == "" )
                validData = false;
            if(EndDate == null || EndDate == "")
                validData = false;
            return validData;
        }

    }
}
