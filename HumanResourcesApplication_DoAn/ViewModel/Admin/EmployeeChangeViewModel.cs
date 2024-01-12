using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using Microsoft.Win32;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class EmployeeChangeViewModel:ViewModelBase
    {
        private User? _selectedItem;
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
        public User? SelectedItem 
        { 
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
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
        public ViewModelCommand ClickChangeEmployeeCommand { get;  }
        public ViewModelCommand ClickCancelCommand { get; }
        public ViewModelCommand UploadImageCommand { get; }
        public EmployeeChangeViewModel(User SelectedItem)
        {
            _selectedItem = SelectedItem;
            _loginName = SelectedItem.loginName;
            UploadImageCommand = new ViewModelCommand(ExecuteUploadImageCommand);
            changeProfileRepository = new Admin_ChangeProfileRepository();
            ClickChangeEmployeeCommand = new ViewModelCommand(ExcuteChangeEmployeeCommand, CanExcuteChangeEmployeeCommand);
            ClickCancelCommand = new ViewModelCommand(ExcuteCancelCommand);

        }

        private bool CanExcuteChangeEmployeeCommand(object? obj)
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
                if (DepartmentId != null && DepartmentId != "")
                    canExecute = true;
                if (JoinDate != null && JoinDate != "")
                    canExecute = true;
                if (PayrollId != null && PayrollId != "")
                    canExecute = true;
                if (RoleId != null && RoleId != "")
                    canExecute = true;
                return canExecute;
            
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

        private void ExcuteChangeEmployeeCommand(object? obj)
        {
            DateOfBirth = "";
            JoinDate = "";
            Country = "";
            RoleId = "";
            Education = "";
            PayrollId = "";
            changeProfileRepository.ChangeProfile(LoginName, UserName, Password, IsAdmin, PhoneNumber, DateOfBirth, Country, Education, Gender, JoinDate, RoleId, PayrollId, Facebook, Twitter, LinkedIn, Email, FileName, DepartmentId);
            if(NewPath == null) 
            {
                FilePath = SelectedItem.avatar; 
            }
            else if (!File.Exists(NewPath))
                File.Copy(FilePath, NewPath);
            MessageBox.Show("Success!");
            MyApp.currentUser.avatar = FilePath;
            Application.Current.MainWindow.Close();
        }
    }
}
