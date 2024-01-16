using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.Views.Admin;
using Microsoft.Win32;
using Org.BouncyCastle.Bcpg;
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
        private DateTime _dateOfBirth;
        private List<Country> _countries;
        private List<string> _sourceCountry;
        private List<Education> _listEducation;
        private List<string> _sourceEducation;
        private List<string> _sourceGender;
        private List<PayrollBase> _listRole;
        private List<string> _sourceRoleId;
        private List<Model.Department> _listDepartment;
        private List<string> _sourceDepartment;
        private string? _gender;
        private string? _country;
        private string? _education;
        private string? _roleId;
        private string? _facebook;
        private string? _twitter;
        private string? _linkedIn;
        private DateTime _joinDate;
        private string? _departmentId;
        private string? _payrollId;
        private string? _email;
        private string? _avatar;
        private string? _filePath;
        private string? _newPath;
        private string? _fileName;
        public ChangeDate changeDate;
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
        public DateTime DateOfBirth { get => _dateOfBirth; set { _dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); } }
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

        public DateTime JoinDate { get => _joinDate; set { _joinDate = value; OnPropertyChanged(nameof(JoinDate)); } }
        public string? DepartmentId { get => _departmentId; set { _departmentId = value; OnPropertyChanged(nameof(DepartmentId)); } }
        public string? PayrollId { get => _payrollId; set { _payrollId = value; OnPropertyChanged(nameof(PayrollId)); } }
        public IAdmin_ChangeProfileRepository changeProfileRepository;
        public IUserRepository userRepository;
        public ViewModelCommand ChangeCommand { get; }
        public ViewModelCommand CancelCommand { get; }
        public ViewModelCommand UploadImageCommand { get; }
        public IListPayrollBase listPayrollBase;
        public IListCountry listCountry;
        public IListEducation listEducation;
        public IListDepartmentRepository departmentRepository;
        public List<string> SourceCountry { get => _sourceCountry; set { _sourceCountry = value; OnPropertyChanged(nameof(SourceCountry)); } }

        public List<Country> Countries { get => _countries; set { _countries = value; OnPropertyChanged(nameof(Countries)); } }

        public List<Education> ListEducation { get => _listEducation; set { _listEducation = value; OnPropertyChanged(nameof(ListEducation)); } }
        public List<string> SourceEducation { get => _sourceEducation; set { _sourceEducation = value; OnPropertyChanged(nameof(SourceEducation)); } }

        public List<string> SourceGender { get => _sourceGender; set { _sourceGender = value; OnPropertyChanged(nameof(SourceGender)); } }

        public List<PayrollBase> ListRole { get => _listRole; set { _listRole = value; OnPropertyChanged(nameof(ListRole)); } }
        public List<string> SourceRoleId { get => _sourceRoleId; set { _sourceRoleId = value; OnPropertyChanged(nameof(SourceRoleId)); } }
        public List<Model.Department> ListDepartment { get => _listDepartment; set { _listDepartment = value; OnPropertyChanged(nameof(ListDepartment)); } }
        public List<string> SourceDepartment { get => _sourceDepartment; set { _sourceDepartment = value; OnPropertyChanged(nameof(SourceDepartment)); } }

        public User_ChangeInformation_ViewModel()
        {
            userRepository = new UserRepository(); 
            departmentRepository = new ListDepartmentRepository();
            ListDepartment = departmentRepository.ListDepartment();
            SourceDepartment = new List<string> { };
            foreach(Model.Department department in ListDepartment)
            {
                SourceDepartment.Add(department.departmentName);
            }
            SourceGender = new List<string>() {"Nam","Nữ"};
            listEducation = new ListEducation();
            ListEducation = listEducation.ListEducations();
            SourceEducation = new List<string>();
            foreach (Education education in ListEducation)
            {
                SourceEducation.Add(education.educationName);
            }
            listPayrollBase = new ListPayrollBase();
            ListRole = listPayrollBase.ListPayrollBaseFunc();
            listCountry = new ListCountryRepository();
            Countries = listCountry.ListCountry();
            SourceCountry = new List<string>();
            foreach (Country country in Countries)
            {
                SourceCountry.Add(country.countryName);
            }
            SourceRoleId = new List<string>();
            foreach(PayrollBase payrollBase in ListRole)
            {
                SourceRoleId.Add(payrollBase.role.roleName);
            }
            User = userRepository.GetByLoginName(MyApp.currentUser.loginName);
            UserName = User.userName;
            LoginName = User.loginName;
            Password = User.password;
            IsAdmin = User.isAdmin.ToString();
            PhoneNumber = User.phoneNumber;
            DateOfBirth = DateTime.Parse(User.dateOfBirth.Value.ToString());
            Gender = User.gender;
            Country = User.countryId;
            Education =  User.educationId;
            RoleId = User.roleId;
            Facebook = User.facebook;
            Twitter = User.twitter;
            LinkedIn=User.linkedIn;
            JoinDate = DateTime.Parse(User.joinDate.Value.ToString());
            DepartmentId= User.departmentId;
            PayrollId= User.payrollId;
            Email=User.email;
            Avatar=User.avatar;
            changeDate = new ChangeDate();
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
            string tempJoinDate = changeDate.ChangeDateFormat(JoinDate);
            string tempDateOfBirth = changeDate.ChangeDateFormat(DateOfBirth);
            foreach(Model.Department department in ListDepartment)
            {
                if(DepartmentId == department.departmentName)
                {
                    DepartmentId = department.departmentId;
                }
            }
            if (Gender == "Nam") Gender = "1";
            else Gender = "0";
            foreach(Country country in Countries)
            {
                if(Country ==  country.countryName)
                {
                    Country = country.countryId;
                }
            }
            foreach(Education education in ListEducation)
            {
                if(Education == education.educationName)
                {
                    Education = education.educationId;
                }
            }
            foreach(PayrollBase payrollBase in ListRole)
            {
                if(payrollBase.role.roleName == RoleId)
                {
                    RoleId = payrollBase.role.roleId;
                }
            }
            foreach(PayrollBase payrollBase1 in ListRole)
            {
                if(PayrollId  == payrollBase1.salary.ToString())
                {
                    PayrollId = payrollBase1.payrollId;
                }
            }
            changeProfileRepository.ChangeProfile(MyApp.currentUser.loginName, UserName, Password,IsAdmin, PhoneNumber, tempDateOfBirth,Country,Education, Gender,tempJoinDate,RoleId,PayrollId, Facebook, Twitter, LinkedIn, Email, FileName, DepartmentId);
            if(NewPath == null)
            {
                FilePath = User.avatar;
            }
            else if (!File.Exists(NewPath))
                File.Copy(FilePath, NewPath);
            MessageBox.Show("Success!");
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
            if (DateOfBirth != null)
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
            if(JoinDate!=null)
                canExecute = true;
            if(PayrollId!=null && PayrollId!="")
                canExecute = true;
            if(RoleId !=null && RoleId !="")
                canExecute=true;
            return canExecute;
        }
    }
}
