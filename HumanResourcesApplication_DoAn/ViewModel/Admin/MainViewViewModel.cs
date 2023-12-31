﻿using HumanResourcesApplication_DoAn.ViewModel.EmployeeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    class MainViewViewModel:ViewModelBase
    {
        private UserViewModel _userViewModel;
        private EmployeeMainViewViewModel _employeeMainViewViewModel;
        private DashBoardViewModel _dashboardViewModel;
        private PayrollViewModel _payrollViewModel;
        private DepartmentViewModel _departmentViewModel;
        private ViewModelBase _currentChildView;
        private AttendanceViewModel _attendanceViewModel;
        private string _caption;
        

        //properties
        public UserViewModel UserViewModel 
        { 
            get => _userViewModel; 
            set
            {
                _userViewModel = value;
                OnPropertyChanged(nameof(UserViewModel));
            } 
        }
        public EmployeeMainViewViewModel EmployeeAllViewViewModel 
        { 
            get => _employeeMainViewViewModel;
            set
            {
                _employeeMainViewViewModel = value;
                OnPropertyChanged(nameof(EmployeeMainViewViewModel));   
            }
        }
        public DashBoardViewModel DashboardViewModel 
        { 
            get => _dashboardViewModel; 
            set
            {
                _dashboardViewModel = value;
                OnPropertyChanged(nameof(DashboardViewModel));
            } 
        }
        public PayrollViewModel PayrollViewModel
        {
            get => _payrollViewModel;
            set
            {
                _payrollViewModel = value;
                OnPropertyChanged(nameof(PayrollViewModel));
            }
        }
        public DepartmentViewModel DepartmentViewModel 
        { 
            get => _departmentViewModel;
            set
            {
                _departmentViewModel = value;
                OnPropertyChanged(nameof(DepartmentViewModel));
            } 
        }
        public ViewModelBase CurrentChildView 
        { 
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));    
            }
        }
        public string Caption 
        { 
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public AttendanceViewModel AttendanceViewModel 
        { 
            get => _attendanceViewModel; 
            set
            {
                _attendanceViewModel = value;
                OnPropertyChanged(nameof(AttendanceViewModel)); 
            }
        }

        //Command
        public ViewModelCommand ShowDashBoardViewCommand { get; }
        public ViewModelCommand ShowDepartmentViewCommand {  get; }
        public ViewModelCommand ShowAccountViewCommand { get; }
        public ViewModelCommand ShowEmployeeMainViewCommand { get; }
        public ViewModelCommand ShowAttendanceViewCommand {  get; }
        public ViewModelCommand ShowPayrollViewCommand { get; }
        

        //Constructor
        public MainViewViewModel()
        {
            //initialize commands
            ShowAccountViewCommand = new ViewModelCommand(ExcuteShowAccountViewCommand);
            ShowAttendanceViewCommand = new ViewModelCommand(ExcuteShowAttendanceViewCommand);
            ShowDashBoardViewCommand = new ViewModelCommand(ExcuteShowDashBoardViewCommand);
            ShowDepartmentViewCommand = new ViewModelCommand(ExcuteShowDepartmentViewCommand);
            ShowEmployeeMainViewCommand = new ViewModelCommand(ExcuteShowEmployeeMainViewCommand);
            ShowPayrollViewCommand = new ViewModelCommand(ExcuteShowPayrollViewCommand);
            //default view
            ExcuteShowDashBoardViewCommand(null);
            
        }

        private void ExcuteShowEmployeeMainViewCommand(object? obj)
        {
            if (_employeeMainViewViewModel == null) 
            {
                _employeeMainViewViewModel = new ();
            }
            CurrentChildView = _employeeMainViewViewModel;
            Caption = "Employee";
        }

        private void ExcuteShowDepartmentViewCommand(object? obj)
        {
            if(_departmentViewModel == null)
            {
                _departmentViewModel = new DepartmentViewModel();
            }
            CurrentChildView = _departmentViewModel;
            Caption = "Department";
            
        }

        private void ExcuteShowDashBoardViewCommand(object? obj)
        {
            if(_dashboardViewModel == null)
            {
                _dashboardViewModel = new DashBoardViewModel();
            }
            CurrentChildView = _dashboardViewModel;
            Caption = "Dashboard";
        }

        private void ExcuteShowAttendanceViewCommand(object? obj)
        {
            if(_attendanceViewModel == null)
                _attendanceViewModel = new AttendanceViewModel();
            CurrentChildView=_attendanceViewModel;
            Caption = "Attendance";
        }

        private void ExcuteShowAccountViewCommand(object? obj)
        {
            if(_userViewModel == null)
                _userViewModel = new UserViewModel();
            CurrentChildView = _userViewModel;
            Caption = "User";
        }
        private void ExcuteShowPayrollViewCommand(object? obj)
        {
            if(_payrollViewModel == null)
                _payrollViewModel = new PayrollViewModel();
            CurrentChildView = _payrollViewModel;
            Caption = "Payroll";
        }
    }
}
