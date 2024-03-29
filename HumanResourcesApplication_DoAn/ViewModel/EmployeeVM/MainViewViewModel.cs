﻿using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.ViewModel.Login;
using HumanResourcesApplication_DoAn.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class MainViewViewModel : ViewModelBase
    {
        private AccountViewModel _accountViewModel;
        private AttendanceViewModel _attendanceViewModel;
        private DashboardViewModel _dashboardViewModel;
        private ViewModelBase _currentChildView;
        private PayrollViewModel _payrollViewModel;
        private string _caption;
        private bool isViewVisible;
        private User user;
        //properties
        private string _icon;
   
        
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
        public AttendanceViewModel Attendance
        {
            get => _attendanceViewModel;
            set
            {
                _attendanceViewModel = value;
                OnPropertyChanged(nameof(Attendance));
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
        public User User { get => user; set { user = value; OnPropertyChanged(nameof(User)); } }
        public bool IsViewVisible { get => isViewVisible; set { isViewVisible = value; OnPropertyChanged(nameof(isViewVisible)); } }
        public AccountViewModel AccountViewModel { get => _accountViewModel; set { _accountViewModel =value; OnPropertyChanged(nameof(AccountViewModel)); } }
        //commands
        public ICommand ShowDashboardViewCommand { get; }
        public ICommand ShowAttendanceViewCommand {  get; }
        public ICommand ShowAccountViewCommand { get; }
        public ViewModelCommand ShowPayrollViewCommand { get; }
        public ViewModelCommand LogoutCommand {get; }
        internal DashboardViewModel DashboardViewModel { get => _dashboardViewModel; set { _dashboardViewModel = value; OnPropertyChanged(nameof(DashboardViewModel)); } }

        public string Icon { get => _icon; set { _icon = value; OnPropertyChanged(nameof(_icon)); } }

        public MainViewViewModel()
        {
            //Initialize commands
            BindingImage bindingIcon = new BindingImage();

            Icon = bindingIcon.ConvertPath("favicon.ico");
            isViewVisible = true;
            user = new User();
            user = MyApp.currentUser;
            ShowAccountViewCommand = new ViewModelCommand(ExcuteShowAccountViewCommand);
            ShowAttendanceViewCommand = new ViewModelCommand(ExcuteShowAttendanceViewCommand);
            ShowDashboardViewCommand = new ViewModelCommand(ExcuteShowDashboardViewCommand);
            LogoutCommand = new ViewModelCommand(ExcuteLogoutCommand);
            ShowPayrollViewCommand = new ViewModelCommand(ExcuteShowPayrollViewCommand);
            //Default view
            ExcuteShowDashboardViewCommand(null);
        }

        private void ExcuteShowDashboardViewCommand(object? obj)
        {
            if(_dashboardViewModel==null)
                _dashboardViewModel = new DashboardViewModel();
            CurrentChildView = _dashboardViewModel;
            Caption = "Dashboard";
        }

        private void ExcuteShowPayrollViewCommand(object? obj)
        {
            if(_payrollViewModel == null)
            {
                _payrollViewModel = new PayrollViewModel();
            }
            CurrentChildView = _payrollViewModel;
            Caption = "Payroll";
        }

        private void ExcuteLogoutCommand(object? obj)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                IsViewVisible = false;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.DataContext = new LoginViewModel();
                loginWindow.ShowDialog();
            }
            else return;
        }

        private void ExcuteShowAttendanceViewCommand(object obj)
        {
            CurrentChildView = new AttendanceViewModel();
            Caption = "Attendance";
        }

        private void ExcuteShowAccountViewCommand(object obj)
        {
            if (_accountViewModel == null)
                _accountViewModel = new AccountViewModel();
            CurrentChildView = _accountViewModel;
            Caption = "Account";
        }
    }

}
