using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class ChangeProfileVM : ViewModelBase
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
        public ICommand ChangeCommand { get; }
        public ICommand CancelCommand { get; }

        private IChangeProfileRepository changeProfileRepository;

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


        public ChangeProfileVM()
        {
            ChangeCommand = new ViewModelCommand(ExecuteChangeCommand, CanExecuteChangeCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            changeProfileRepository = new ChangeProfileRepository();
        }

        private bool CanExecuteChangeCommand(object? obj)
        {
            bool canExecute = false;
            if (UserName != null && UserName != "")
                canExecute = true;
            if (Password != null && Password != "")
                canExecute = true;
            if (PhoneNumber != null && PhoneNumber != "")
                canExecute = true;
            if(DateOfBirth != null && DateOfBirth != "")
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
            if (Avatar != null & Avatar != "")
                canExecute = true;
            return canExecute;
        }

        private void ExecuteChangeCommand(object? obj)
        {
            changeProfileRepository.ChangeProfile(MyApp.currentUser.loginName, UserName, Password, PhoneNumber, DateOfBirth, Gender, Country, Education, Facebook, Twitter, LinkedIn, Email, Avatar);
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
