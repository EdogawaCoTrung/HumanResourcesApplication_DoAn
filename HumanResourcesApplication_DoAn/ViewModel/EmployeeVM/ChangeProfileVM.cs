using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class ChangeProfileVM : ViewModelBase
    {
        private User _user;
        private string? _userName;
        private string? _loginName;
        private string? _password;
        private string? _phoneNumber;
        private DateTime _dateOfBirth;
        private string? _gender;
        private string? _country;
        private string? _education;
        private string? _role;
        private string? _facebook;
        private string? _twitter;
        private string? _linkedIn;
        private string? _email;
        private string? _avatar;
        private string? _filePath;
        private string? _newPath;
        private string? _fileName;
        private List<Country> _listCountry;
        private List<string> _sourceCountry;
        private List<Education> _listEducation;
        private List<string> _sourceEducation;
        private List<string> _sourceGender;
        public ICommand ChangeCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand UploadImageCommand { get; }
        public IUserRepository userRepository;

        private IChangeProfileRepository changeProfileRepository;
        public List<Country> ListCountry { get => _listCountry; set { _listCountry = value; OnPropertyChanged(nameof(ListCountry)); } }
        public List<string> SourceCountry { get => _sourceCountry; set { _sourceCountry = value; OnPropertyChanged(nameof(SourceCountry)); } }
        public List<Education> ListEducation { get => _listEducation; set { _listEducation = value; OnPropertyChanged(nameof(ListEducation)); } }
        public List<string> SourceEducation { get => _sourceEducation; set { _sourceEducation = value; OnPropertyChanged(nameof(SourceEducation)); } }
        public List<string> SourceGender { get => _sourceGender; set { _sourceGender = value; OnPropertyChanged(nameof(SourceGender)); } }

        public string? UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); } }
        public string? LoginName { get => _loginName; set { _loginName = value; OnPropertyChanged(nameof(LoginName)); } }
        public string? Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string? PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); } }
        public DateTime DateOfBirth { get => _dateOfBirth; set { _dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); } }
        public string? Gender { get => _gender; set { _gender = value; OnPropertyChanged(nameof(Gender)); } }
        public string? Country { get => _country; set { _country = value; OnPropertyChanged(nameof(Country)); } }
        public string? Education { get => _education; set { _education = value; OnPropertyChanged(nameof(Education)); } }
        public string? Role { get => _role; set { _role = value; OnPropertyChanged(nameof(Role)); } }
        public string? Facebook { get => _facebook; set { _facebook = value; OnPropertyChanged(nameof(Facebook)); } }
        public string? Twitter { get => _twitter; set { _twitter = value; OnPropertyChanged(nameof(Twitter)); } }
        public string? LinkedIn { get => _linkedIn; set { _linkedIn = value; OnPropertyChanged(nameof(LinkedIn)); } }
        public string? Email { get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); } }
        public string? Avatar { get => _avatar; set { _avatar = value; OnPropertyChanged(nameof(Avatar)); } }
        public string? FilePath { get => _filePath; set { _filePath = value; OnPropertyChanged(nameof(FilePath)); } }
        public string? NewPath { get => _newPath; set { _newPath = value; OnPropertyChanged(nameof(NewPath)); } }
        public string? FileName { get => _fileName; set { _fileName = value; OnPropertyChanged(nameof(FileName)); } }
        public ChangeDate changeDate;
        public User User { get => _user; set { _user = value; OnPropertyChanged(nameof(User)); } }
        public IListCountry listCountry;
        public IListEducation listEducation;
        public ChangeProfileVM()
        {
            changeDate = new ChangeDate();
            listCountry = new ListCountryRepository();
            listEducation = new ListEducation();
            userRepository = new UserRepository();
            User = userRepository.GetByLoginName(MyApp.currentUser.loginName);
            UserName = User.userName;
            LoginName = User.loginName;
            Password = User.password;
            PhoneNumber = User.phoneNumber;
            DateOfBirth = DateTime.Parse(User.dateOfBirth.Value.ToString());
            Gender = User.gender;
            Country = User.countryId;
            Education = User.educationId;
            Role = User.roleId;
            Facebook=User.facebook;
            LinkedIn = User.linkedIn;
            Email = User.email;
            Twitter = User.twitter;
            Avatar = User.avatar;
            ChangeCommand = new ViewModelCommand(ExecuteChangeCommand, CanExecuteChangeCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            UploadImageCommand = new ViewModelCommand(ExecuteUploadImageCommand, CanExecuteUploadImageCommand);
            changeProfileRepository = new ChangeProfileRepository();
            SourceGender = new List<string> { "Nam", "Nữ" };
            //List country
            listCountry = new ListCountryRepository();
            ListCountry = listCountry.ListCountry();
            SourceCountry = new List<string>();
            foreach (Country country in ListCountry)
            {
                SourceCountry.Add(country.countryName);
            }

            listEducation = new ListEducation();
            ListEducation = listEducation.ListEducations();
            SourceEducation = new List<string>();
            foreach (Education e in ListEducation)
            {
                SourceEducation.Add(e.educationName);
            }
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

        private bool CanExecuteChangeCommand(object? obj)
        {
            bool canExecute = false;
            if (UserName != null && UserName != "")
                canExecute = true;
            if (Password != null && Password != "")
                canExecute = true;
            if (PhoneNumber != null && PhoneNumber != "")
                canExecute = true;
            if(DateOfBirth != null)
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
            return canExecute;
        }

        private void ExecuteChangeCommand(object? obj)
        {
            string tempDateOfBirth = changeDate.ChangeDateFormat(DateOfBirth);
            if (Gender == "Nam") Gender = "1";
            else Gender = "0";
            foreach (Country country in ListCountry)
            {
                if (Country == country.countryName)
                {
                    Country = country.countryId;
                }
            }
            foreach (Education education in ListEducation)
            {
                if (Education == education.educationName)
                {
                    Education = education.educationId;
                }
            }
            changeProfileRepository.ChangeProfile(MyApp.currentUser.loginName, UserName, Password, PhoneNumber, tempDateOfBirth, Gender, Country, Education, Facebook, Twitter, LinkedIn, Email, FileName);
            if (NewPath == null)
            {
                NewPath = User.avatar;
            }
            if (!File.Exists(NewPath))
                 File.Copy(FilePath, NewPath);
            MyApp.currentUser.avatar = FilePath;
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
