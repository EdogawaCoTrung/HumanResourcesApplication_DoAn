using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.Views.Admin;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class EmployeeAddUserVM : ViewModelBase
    {
        private string? _userName;
        private string? _loginName;
        private string? _password;
        private string? _phoneNumber;
        private string? _dateOfBirth;
        private string? _gender;
        private string? _country;
        private string? _education;
        private string? _role;
        private string? _facebook;
        private string? _twitter;
        private string? _linkedIn;
        private string? _email;
        private string? _avatar;
        private string? _isAdmin;
        private string? _joinDate;
        private string? _payroll;
        private string? _filePath;
        private string? _fileName;
        private string? _newPath;
        private string? _departmentId;
        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand UploadImageCommand { get; }
        public IAddUserRepository addUserRepository { get; }

        public string? UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); } }
        public string? LoginName { get => _loginName; set { _loginName = value; OnPropertyChanged(nameof(LoginName)); } }
        public string? Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string? PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); } }
        public string? DateOfBirth { get => _dateOfBirth; set { _dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); } }
        public string? Gender { get => _gender; set { _gender = value; OnPropertyChanged(nameof(Gender)); } }
        public string? Country { get => _country; set { _country = value; OnPropertyChanged(nameof(Country)); } }
        public string? Education { get => _education; set { _education = value; OnPropertyChanged(nameof(Education)); } }
        public string? Role { get => _role; set { _role = value; OnPropertyChanged(nameof(Role)); } }
        public string? Facebook { get => _facebook; set { _facebook = value; OnPropertyChanged(nameof(Facebook)); } }
        public string? Twitter { get => _twitter; set { _twitter = value; OnPropertyChanged(nameof(Twitter)); } }
        public string? LinkedIn { get => _linkedIn; set { _linkedIn = value; OnPropertyChanged(nameof(LinkedIn)); } }
        public string? Email { get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); } }
        public string? Avatar { get => _avatar; set { _avatar = value; OnPropertyChanged(nameof(Avatar)); } }

        public string? IsAdmin { get => _isAdmin; set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }
        public string? JoinDate { get => _joinDate; set { _joinDate = value; OnPropertyChanged(nameof(JoinDate)); } }
        public string? Payroll { get => _payroll; set { _payroll = value; OnPropertyChanged(nameof(Payroll)); } }

        public string? FilePath { get => _filePath; set { _filePath = value; OnPropertyChanged(nameof(FilePath)); } }
        public string? FileName { get => _fileName; set { _fileName = value; OnPropertyChanged(nameof(FileName)); } }
        public string? NewPath { get => _newPath; set { _newPath = value; OnPropertyChanged(nameof(NewPath)); } }

        public string? DepartmentId { get => _departmentId; set { _departmentId = value; OnPropertyChanged(nameof(DepartmentId)); } }

        public EmployeeAddUserVM()
        {
            AddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            UploadImageCommand = new ViewModelCommand(ExecuteUploadImageCommand, CanExecuteUploadImageCommand);
            addUserRepository = new AddUserRepository();
        }

        private bool CanExecuteUploadImageCommand(object? obj)
        {
            return true;
        }

        private void ExecuteUploadImageCommand(object? obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? response = openFileDialog.ShowDialog();
            if (response == true)
            {
                string? filePath = openFileDialog.FileName;
                string? fileName = Path.GetFileName(filePath);
                BindingImage bindingImage = new BindingImage();
                string? newPath = fileName;
                newPath = bindingImage.ConvertPath(newPath);
                FilePath = filePath;
                FileName = fileName;
                NewPath = newPath;
            }
        }

        private bool CanExecuteAddCommand(object? obj)
        {
            bool canExecute = true;
            if (UserName == null || UserName == "")
                canExecute = false;
            if (LoginName == null || LoginName == "")
                canExecute = false;
            if (Password == null || Password == "")
                canExecute = false;
            if (IsAdmin == null || IsAdmin == "")
                canExecute = false;
            if (PhoneNumber == null || PhoneNumber == "")
                canExecute = false;
            if (DateOfBirth == null || DateOfBirth == "")
                canExecute = false;
            if (Country == null || Country == "")
                canExecute = false;
            if (Education == null || Education == "")
                canExecute = false;
            if (Gender == null || Gender == "")
                canExecute = false;
            if (JoinDate == null || JoinDate == "")
                canExecute = false;
            if (Role == null || Role == "")
                canExecute = false;
            if (Payroll == null || Payroll == "")
                canExecute = false;
            if (Facebook == null || Facebook == "")
                canExecute = false;
            if (Twitter == null || Twitter == "")
                canExecute = false;
            if (LinkedIn == null || LinkedIn == "")
                canExecute = false;
            if (Email == null || Email == "")
                canExecute = false;
            if (Avatar == null & Avatar == "")
                canExecute = false;
            if (DepartmentId == null & DepartmentId == "")
                canExecute = false;
            return canExecute;
        }

        private void ExecuteAddCommand(object? obj)
        {
            addUserRepository.AddUser(UserName, LoginName, Password, IsAdmin, PhoneNumber, DateOfBirth, Country, Education, Gender, JoinDate, Role, Payroll, Facebook, Twitter, LinkedIn, Email, FileName,DepartmentId);
            if (!File.Exists(NewPath))
                File.Copy(FilePath, NewPath);
            Application.Current.MainWindow.Close();
        }

        private void ExecuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close();
        }

        private bool CanExecuteCancelCommand(object? obj)
        {
            return true;
        }
    }
}
