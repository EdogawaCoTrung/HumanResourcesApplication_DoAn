using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.Views.Admin;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class User_ChangeInformation_ViewModel:ViewModelBase
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
        public IAdmin_ChangeProfileRepository changeProfileRepository;
        public ViewModelCommand ChangeCommand { get; }
        public ViewModelCommand CancelCommand { get; }
        public ViewModelCommand UploadImageCommand { get; }
        

        public User_ChangeInformation_ViewModel()
        {
            
            User = MyApp.currentUser;
            _userName = User.userName;
            _loginName = User.loginName;
            _password = User.password;
            _isAdmin = User.isAdmin.ToString();
            _phoneNumber = User.phoneNumber;
            _dateOfBirth = User.dateOfBirth.ToString();
            _gender = User.gender;
            _country = User.countryId;
            _education =  User.educationId;
            _roleId = User.roleId;
            _facebook = User.facebook;
            _twitter = User.twitter;
            _linkedIn=User.linkedIn;
            _joinDate = User.joinDate.ToString();
            _departmentId= User.departmentId;
            _payrollId= User.payrollId;
            _email=User.email;
            _avatar=User.avatar;
            changeProfileRepository = new Admin_ChangeProfileRepository();
            ChangeCommand = new ViewModelCommand(ExcuteChangeCommand,CanExcuteChangeCommand);
            CancelCommand = new ViewModelCommand(ExcuteCancelCommand);
            UploadImageCommand = new ViewModelCommand(ExecuteUploadImageCommand);
        }
        private void ExecuteUploadImageCommand(object? obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? response = openFileDialog.ShowDialog();
            if (response == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                BindingImage bindingImage = new BindingImage();
                string newPath = fileName;
                newPath = bindingImage.ConvertPath(newPath);
                FilePath = filePath;
                FileName = fileName;
                NewPath = newPath;
                Avatar = newPath;
            }
        }
        private void ExcuteCancelCommand(object? obj)
        {
            
            Application.Current.MainWindow.Close();
        }
        private void ExcuteChangeCommand(object? obj)
        {
            DateOfBirth = "";
            JoinDate ="";
            Country ="";
            RoleId="";
            PayrollId="";
            changeProfileRepository.ChangeProfile(MyApp.currentUser.loginName, UserName, Password,IsAdmin, PhoneNumber, DateOfBirth,Country,Education, Gender,JoinDate,RoleId,PayrollId, Facebook, Twitter, LinkedIn, Email, FileName, DepartmentId);
            if (!File.Exists(NewPath))
                File.Copy(FilePath, NewPath);
            MyApp.currentUser.avatar = FilePath;
            Application.Current.MainWindow.Close();
        }
        private bool CanExcuteChangeCommand(object? obj)
        {
            bool canExecute = false;
            if (UserName != null && UserName != "")
                canExecute = true;
            if (Password != null && Password != "")
                canExecute = true;
            if (PhoneNumber != null && PhoneNumber != "")
                canExecute = true;
            if (DateOfBirth != null && DateOfBirth != "")
                canExecute = true;
            if (Gender != null && Gender != "")
                canExecute = true;
            if (Country != null && Country != "")
                canExecute = true;
            if (Education != null && Education != "")
                canExecute = true;
            if (Facebook != null && Facebook != "")
                canExecute = true;
            if (Twitter != null && Twitter != "")
                canExecute = true;
            if (LinkedIn != null && LinkedIn != "")
                canExecute = true;
            if (Email != null && Email != "")
                canExecute = true;
            if (Avatar != null && Avatar != "")
                canExecute = true;
            if (DepartmentId!=null && DepartmentId !="")
                canExecute = true;
            if(JoinDate!=null && JoinDate !="")
                canExecute = true;
            if(PayrollId!=null && PayrollId!="")
                canExecute = true;
            if(RoleId !=null && RoleId !="")
                canExecute=true;
            return canExecute;
        }
    }
}
