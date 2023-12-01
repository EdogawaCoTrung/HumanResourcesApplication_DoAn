using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.ViewModel.EmployeeVM;
using HumanResourcesApplication_DoAn.Views.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class EmployeeMainViewViewModel:ViewModelBase
    {
        //fields
        ViewModelBase _currentEmployeeChildView;
        EmployeeAllViewModel _employeeAllViewModel;
        LeaveRequestsViewModel _leaveRequestsViewModel;
        EmployeeViewViewModel _employeeViewViewModel;
        User _selectedItem;
        //properties
        public ViewModelBase CurrentEmployeeChildView 
        {   get => _currentEmployeeChildView;
            set
            {
                _currentEmployeeChildView = value;
                OnPropertyChanged(nameof(CurrentEmployeeChildView));
            }

        }
        public EmployeeAllViewModel EmployeeAllViewModel 
        { 
            get => _employeeAllViewModel; 
            set
            {
                _employeeAllViewModel = value;
                OnPropertyChanged(nameof(EmployeeAllViewModel));
            }
        }
        public LeaveRequestsViewModel LeaveRequestsViewModel 
        { 
            get => _leaveRequestsViewModel; 
            set
            {
                _leaveRequestsViewModel = value;
                OnPropertyChanged(nameof(LeaveRequestsViewModel));
            }
        }
        internal EmployeeViewViewModel EmployeeViewViewModel 
        { 
            get => _employeeViewViewModel; 
            set
            {
                _employeeViewViewModel = value;
                OnPropertyChanged(nameof(EmployeeViewViewModel));
            }
        }
        public User SelectedItem
        {
            get => _selectedItem;

            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        //Commands
        public ViewModelCommand ShowEmployeeAllViewCommand { get; }
        public ViewModelCommand ShowLeaveRequestViewCommand { get; }
        public ViewModelCommand ShowEmployeeViewCommand { get; }
        

        //Constructor
        public EmployeeMainViewViewModel()
        {

            ShowEmployeeAllViewCommand = new ViewModelCommand(ExcuteShowEmployeeAllViewCommand);
            ShowLeaveRequestViewCommand = new ViewModelCommand(ExcuteShowEmployeeLeaveRequestViewCommand);
            //default view 
            _employeeAllViewModel = new EmployeeAllViewModel(this);
            CurrentEmployeeChildView = _employeeAllViewModel;
        }

        private void ExcuteShowEmployeeLeaveRequestViewCommand(object? obj)
        {
            if (_leaveRequestsViewModel == null) 
                _leaveRequestsViewModel = new LeaveRequestsViewModel();
            CurrentEmployeeChildView = _leaveRequestsViewModel;
        }

        

        private void ExcuteShowEmployeeAllViewCommand(object? obj)
        {
            if (_employeeAllViewModel == null) 
                _employeeAllViewModel = new EmployeeAllViewModel(this);
            CurrentEmployeeChildView = _employeeAllViewModel;
        }
    }
}
