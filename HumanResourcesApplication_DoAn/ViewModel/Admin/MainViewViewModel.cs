using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.ViewModel.EmployeeVM;
using HumanResourcesApplication_DoAn.ViewModel.Login;
using HumanResourcesApplication_DoAn.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class MainViewViewModel : ViewModelBase
    {
        User _user;
        private UserViewModel _userViewModel;
        private EmployeeMainViewViewModel _employeeMainViewViewModel;
        private DashBoardViewModel _dashboardViewModel;
        private PayrollMainViewViewModel _payrollViewModel;
        private DepartmentViewModel _departmentViewModel;
        private ViewModelBase _currentChildView;
        private AttendanceViewModel _attendanceViewModel;
        private InsuranceMainViewModel _insuranceViewModel;
        private ProjectMainViewModel _projectMainViewModel;
        private ContractViewModel _contractViewModel;
        private string _caption;
        private bool isViewVisible;
        private string icon;


       
        

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
        public string Icon { get => icon; set { icon = value; OnPropertyChanged(nameof(icon)); } }
        public DashBoardViewModel DashboardViewModel 
        { 
            get => _dashboardViewModel; 
            set
            {
                _dashboardViewModel = value;
                OnPropertyChanged(nameof(DashboardViewModel));
            } 
        }
        public PayrollMainViewViewModel PayrollViewModel
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
        public InsuranceMainViewModel InsuranceViewModel 
        { 
            get => _insuranceViewModel;

            set
            {
                _insuranceViewModel = value;
                OnPropertyChanged(nameof(InsuranceMainViewModel));
            }
        }
        public ProjectMainViewModel ProjectMainViewModel 
        { 
            get => _projectMainViewModel;
            set
            {
                _projectMainViewModel = value;
                OnPropertyChanged(nameof(ProjectMainViewModel));
            }
        }
        public User User { get => _user; set { _user = value; OnPropertyChanged(nameof(User)); }}

        public bool IsViewVisible { get => isViewVisible; set { isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }
        public ContractViewModel ContractViewModel { get => _contractViewModel; set { _contractViewModel = value; OnPropertyChanged(nameof(ContractViewModel)); } }

        //Command
        public ViewModelCommand ShowDashBoardViewCommand { get; }
        public ViewModelCommand ShowContractViewCommand {  get; }
        public ViewModelCommand ShowDepartmentViewCommand {  get; }
        public ViewModelCommand ShowAccountViewCommand { get; }
        public ViewModelCommand ShowEmployeeMainViewCommand { get; }
        public ViewModelCommand ShowAttendanceViewCommand {  get; }
        public ViewModelCommand ShowPayrollViewCommand { get; }
        public ViewModelCommand ShowInsuranceMainViewCommand { get; }
        public ViewModelCommand ShowProjectMainViewCommand { get; }

        public ViewModelCommand LogoutCommand { get; }
      



        //Constructor
        public MainViewViewModel()
        {
            //initialize commands
            BindingImage bindingIcon = new BindingImage();
       
            Icon = bindingIcon.ConvertPath("favicon.ico");
            _user = new User();
            isViewVisible = true;
            _user = MyApp.currentUser; 
            ShowAccountViewCommand = new ViewModelCommand(ExcuteShowAccountViewCommand);
            ShowContractViewCommand = new ViewModelCommand(ExecuteShowContractViewCommand);
            ShowAttendanceViewCommand = new ViewModelCommand(ExcuteShowAttendanceViewCommand);
            ShowDashBoardViewCommand = new ViewModelCommand(ExcuteShowDashBoardViewCommand);
            ShowDepartmentViewCommand = new ViewModelCommand(ExcuteShowDepartmentViewCommand);
            ShowEmployeeMainViewCommand = new ViewModelCommand(ExcuteShowEmployeeMainViewCommand);
            ShowPayrollViewCommand = new ViewModelCommand(ExcuteShowPayrollViewCommand);
            ShowInsuranceMainViewCommand = new ViewModelCommand(ExcuteShowInsureanceMainViewCommand);
            ShowProjectMainViewCommand = new ViewModelCommand(ExcuteShowProjectMainViewCommand);
            LogoutCommand = new ViewModelCommand(ExcuteLogoutCommand);
            //default view
            ExcuteShowDashBoardViewCommand(null);
            
        }

        private void ExecuteShowContractViewCommand(object? obj)
        {
            if(_contractViewModel == null)
            {
                _contractViewModel = new ContractViewModel();
            }
            CurrentChildView = _contractViewModel;
            Caption = "Contract";
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

        private void ExcuteShowProjectMainViewCommand(object? obj)
        {
            if(_projectMainViewModel == null)
            {
                _projectMainViewModel = new ProjectMainViewModel();
            }
            CurrentChildView =  _projectMainViewModel;
            Caption = "Project";
        }

        private void ExcuteShowInsureanceMainViewCommand(object? obj)
        {
            if(_insuranceViewModel == null)
            {
                _insuranceViewModel = new InsuranceMainViewModel();
            }    
            CurrentChildView = _insuranceViewModel;
            Caption = "Insurance";
        }

        private void ExcuteShowEmployeeMainViewCommand(object? obj)
        {
            if (_employeeMainViewViewModel == null) 
            {
                _employeeMainViewViewModel = new EmployeeMainViewViewModel ();
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
                _payrollViewModel = new PayrollMainViewViewModel();
            CurrentChildView = _payrollViewModel;
            Caption = "Payroll";
        }
    }
}
