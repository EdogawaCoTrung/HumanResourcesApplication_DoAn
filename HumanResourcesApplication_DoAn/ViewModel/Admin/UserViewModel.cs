using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.Views.Admin;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class UserViewModel : ViewModelBase
    {
        private string? _userName;
        private string? _loginName;
        private string? _password;
        private string? _isAdmin;
        private string? _phoneNumber;
        private string? _dateOfBirth;
        private string? _gender;
        private string? _country;
        private string? _education;
        private string? _roleId;
        private string? _facebook;
        private string? _twitter;
        private string? _linkedIn;
        private string? _joinDate;
        private string? _departmentId;
        private string? _payrollId;
        private string? _email;
        private string? _avatar;
        private string? _filePath;
        private string? _newPath;
        private string? _fileName;

        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public string? UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); } }
        public string? LoginName { get => _loginName; set { _loginName = value; OnPropertyChanged(nameof(LoginName)); } }
        public string? Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string? PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); } }
        public string? DateOfBirth { get => _dateOfBirth; set { _dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); } }
        public string? Gender { get => _gender; set { _gender = value; OnPropertyChanged(nameof(Gender)); } }
        public string? Country { get => _country; set { _country = value; OnPropertyChanged(nameof(Country)); } }
        public string? Education { get => _education; set { _education = value; OnPropertyChanged(nameof(Education)); } }
        public string? RoleId { get => _roleId; set { _roleId = value; OnPropertyChanged(nameof(RoleId)); } }
        public string? Facebook { get => _facebook; set { _facebook = value; OnPropertyChanged(nameof(Facebook)); } }
        public string? Twitter { get => _twitter; set { _twitter = value; OnPropertyChanged(nameof(Twitter)); } }
        public string? LinkedIn { get => _linkedIn; set { _linkedIn = value; OnPropertyChanged(nameof(LinkedIn)); } }
        public string? Email { get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); } }
        public string? Avatar { get => _avatar; set { _avatar = value; OnPropertyChanged(nameof(Avatar)); } }
        public string? FilePath { get => _filePath; set { _filePath = value; OnPropertyChanged(nameof(FilePath)); } }
        public string? NewPath { get => _newPath; set { _newPath = value; OnPropertyChanged(nameof(NewPath)); } }
        public string? FileName { get => _fileName; set { _fileName = value; OnPropertyChanged(nameof(FileName)); } }
        public string? IsAdmin { get => _isAdmin; set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }

        public string? JoinDate { get => _joinDate; set { _joinDate = value; OnPropertyChanged(nameof(JoinDate)); } }
        public string? DepartmentId { get => _departmentId; set { _departmentId = value; OnPropertyChanged(nameof(DepartmentId)); } }
        public string? PayrollId { get => _payrollId; set { _payrollId = value; OnPropertyChanged(nameof(PayrollId)); } }
        public IUserRepository userRepository;
        //command
        public ViewModelCommand SendLeaveRequestCommand { get; }
        public ViewModelCommand ChangeInformationCommand { get; }
        public UserViewModel()
        {
            _user = new User();
            _user = MyApp.currentUser;
            _userName = User.userName;
            _loginName = User.loginName;
            _password = User.password;
            _isAdmin = User.isAdmin.ToString();
            _phoneNumber = User.phoneNumber;
            _dateOfBirth = User.dateOfBirth.ToString();
            _gender = User.gender;
            _country = User.countryId;
            _education = User.educationId;
            _roleId = User.roleId;
            _facebook = User.facebook;
            _twitter = User.twitter;
            _linkedIn = User.linkedIn;
            _joinDate = User.joinDate.ToString();
            _departmentId = User.departmentId;
            _payrollId = User.payrollId;
            _email = User.email;
            _avatar = User.avatar;
            userRepository = new UserRepository();
            SendLeaveRequestCommand = new ViewModelCommand(ExcuteSendLeaveRequestCommand, CanExcuteSendLeaveRequestCommand);
            ChangeInformationCommand = new ViewModelCommand(ExcuteChangeInformationCommand, CanExcuteChangeInformationCommand);

        }

        private bool CanExcuteChangeInformationCommand(object? obj)
        {
            return true;
        }

        private void ExcuteChangeInformationCommand(object? obj)
        {
            try
            {
                User_ChangeInformation changeUser = new User_ChangeInformation();
                changeUser.DataContext = new User_ChangeInformation_ViewModel();
                changeUser.ShowDialog();
                User = userRepository.GetByLoginName(MyApp.currentUser.loginName);
                UserName = User.userName;
                LoginName = User.loginName;
                Password = User.password;
                IsAdmin = User.isAdmin.ToString();
                PhoneNumber = User.phoneNumber;
                DateOfBirth = User.dateOfBirth.ToString();
                Gender = User.gender;
                Country = User.countryId;
                Education = User.educationId;
                RoleId = User.roleId;
                Facebook = User.facebook;
                Twitter = User.twitter;
                LinkedIn = User.linkedIn;
                JoinDate = User.joinDate.ToString();
                DepartmentId = User.departmentId;
                PayrollId = User.payrollId;
                Email = User.email;
                Avatar = User.avatar;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        private bool CanExcuteSendLeaveRequestCommand(object? obj)
        {
            return true;
        }

        private void ExcuteSendLeaveRequestCommand(object? obj)
        {
            User_AddLeaveRequest leaveRequestView = new User_AddLeaveRequest();
            leaveRequestView.ShowDialog();
        }
    }
}
