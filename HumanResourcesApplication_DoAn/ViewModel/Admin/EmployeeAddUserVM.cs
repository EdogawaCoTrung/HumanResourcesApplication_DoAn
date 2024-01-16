using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.Views.Admin;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
        private DateTime _dateOfBirth;
        private string? _gender;
        private List<string> _sourceGender;
        private string? _country;
        private List<Country> _listCountry;
        private List<string> _sourceCountry;
        private string? _education;
        private List<Education> _listEducation;
        private List<string> _sourceEducation;
        private string? _role;
        private List<PayrollBase> _listPayrollBase;
        private List<string> _sourceRole;
        private string? _facebook;
        private string? _twitter;
        private string? _linkedIn;
        private string? _email;
        private string? _avatar;
        private string? _isAdmin;
        private List<string> _sourceIsAdmin;
        private DateTime _joinDate;
        private string? _payroll;
        private string? _filePath;
        private string? _fileName;
        private string? _newPath;
        private string? _departmentId;
        private List<Model.Department> _listDepartment;
        private List<string> _sourceDepartment;
        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand UploadImageCommand { get; }
        public IAddUserRepository addUserRepository { get; }

        public string? UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); } }
        public string? LoginName { get => _loginName; set { _loginName = value; OnPropertyChanged(nameof(LoginName)); } }
        public string? Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string? PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); } }
        public DateTime DateOfBirth { get => _dateOfBirth; set { _dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); } }
        public string? Gender { get => _gender; set { _gender = value; OnPropertyChanged(nameof(Gender)); } }
        public string? Country { get => _country; set { _country = value; OnPropertyChanged(nameof(Country)); } }
        public string? Education { get => _education; set { _education = value; OnPropertyChanged(nameof(Education)); } }
        public string? Role { get => _role; set { _role = value; OnPropertyChanged(nameof(Role)); UpdatePayroll(); }}

       

        public string? Facebook { get => _facebook; set { _facebook = value; OnPropertyChanged(nameof(Facebook)); } }
        public string? Twitter { get => _twitter; set { _twitter = value; OnPropertyChanged(nameof(Twitter)); } }
        public string? LinkedIn { get => _linkedIn; set { _linkedIn = value; OnPropertyChanged(nameof(LinkedIn)); } }
        public string? Email { get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); } }
        public string? Avatar { get => _avatar; set { _avatar = value; OnPropertyChanged(nameof(Avatar)); } }

        public string? IsAdmin { get => _isAdmin; set { _isAdmin = value; OnPropertyChanged(nameof(IsAdmin)); } }
        public DateTime JoinDate { get => _joinDate; set { _joinDate = value; OnPropertyChanged(nameof(JoinDate)); } }
        public string? Payroll { get => _payroll; set { _payroll = value; OnPropertyChanged(nameof(Payroll)); } }

        public string? FilePath { get => _filePath; set { _filePath = value; OnPropertyChanged(nameof(FilePath)); } }
        public string? FileName { get => _fileName; set { _fileName = value; OnPropertyChanged(nameof(FileName)); } }
        public string? NewPath { get => _newPath; set { _newPath = value; OnPropertyChanged(nameof(NewPath)); } }

        public string? DepartmentId { get => _departmentId; set { _departmentId = value; OnPropertyChanged(nameof(DepartmentId)); } }

        public List<string> SourceGender { get => _sourceGender; set { _sourceGender = value; OnPropertyChanged(nameof(SourceGender)); } }
        public List<Country> ListCountry { get => _listCountry; set { _listCountry = value; OnPropertyChanged(nameof(ListCountry)); } }
        public List<string> SourceCountry { get => _sourceCountry; set { _sourceCountry = value; OnPropertyChanged(nameof(SourceCountry)); } }
        public List<Education> ListEducation { get => _listEducation; set { _listEducation = value; OnPropertyChanged(nameof(ListEducation)); } }
        public List<string> SourceEducation { get => _sourceEducation; set { _sourceEducation = value; OnPropertyChanged(nameof(SourceEducation)); } }
        public List<PayrollBase> ListPayrollBase { get => _listPayrollBase; set { _listPayrollBase = value; OnPropertyChanged(nameof(ListPayrollBase)); } }
        public List<string> SourceRole { get => _sourceRole; set { _sourceRole = value; OnPropertyChanged(nameof(SourceRole)); } }
        public List<string> SourceIsAdmin { get => _sourceIsAdmin; set { _sourceIsAdmin = value; OnPropertyChanged(nameof(SourceIsAdmin)); } }
        public List<Model.Department> ListDepartment { get => _listDepartment; set { _listDepartment = value; OnPropertyChanged(nameof(ListDepartment)); } }
        public List<string> SourceDepartment { get => _sourceDepartment; set { _sourceDepartment = value; OnPropertyChanged(nameof(SourceDepartment)); } }
        public ChangeDate changeDate;
        public IListCountry listCountry;
        public IListEducation listEducation;
        public IListPayrollBase listPayrollBase;
        public IListDepartmentRepository departmentRepository;
        public EmployeeAddUserVM()
        {
            AddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            UploadImageCommand = new ViewModelCommand(ExecuteUploadImageCommand, CanExecuteUploadImageCommand);
            addUserRepository = new AddUserRepository();
            SourceIsAdmin = new List<string>() { "True", "False" };
            SourceGender = new List<string> { "Nam", "Nữ" };
            changeDate = new ChangeDate();  
            //List country
            JoinDate = DateTime.Now;
            DateOfBirth = DateTime.Now;
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

            listPayrollBase = new ListPayrollBase();
            ListPayrollBase = listPayrollBase.ListPayrollBaseFunc();
            SourceRole = new List<string>();
            foreach (PayrollBase payrollBase in ListPayrollBase)
            {
                SourceRole.Add(payrollBase.role.roleName);
            }

            departmentRepository = new ListDepartmentRepository();
            ListDepartment = departmentRepository.ListDepartment();
            SourceDepartment = new List<string>();
            foreach (Model.Department department in ListDepartment)
            {
                SourceDepartment.Add(department.departmentName);
            }
        }

        private bool CanExecuteUploadImageCommand(object? obj)
        {
            return true;
        }
        private void UpdatePayroll()
        {
            foreach (PayrollBase payroll in ListPayrollBase)
            {
                if (Role == payroll.role.roleName) 
                {
                    Payroll = payroll.salary.ToString();
                    break;
                }
            }
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
            if (DateOfBirth == null )
                canExecute = false;
            if (Country == null || Country == "")
                canExecute = false;
            if (Education == null || Education == "")
                canExecute = false;
            if (Gender == null || Gender == "")
                canExecute = false;
            if (JoinDate == null )
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
            string tempDateOfBirth = changeDate.ChangeDateFormat(DateOfBirth);
            string tempJoinDate = changeDate.ChangeDateFormat(JoinDate);
            foreach (Model.Department department in ListDepartment)
            {
                if (DepartmentId == department.departmentName)
                {
                    DepartmentId = department.departmentId;
                }
            }
            if (IsAdmin == "True") IsAdmin = "1";
            else IsAdmin = "0";
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
            foreach (PayrollBase payrollBase in ListPayrollBase)
            {
                if (payrollBase.role.roleName == Role)
                {
                    Role = payrollBase.role.roleId;
                }
            }
            foreach (PayrollBase payrollBase1 in ListPayrollBase)
            {
                if (Payroll == payrollBase1.salary.ToString())
                {
                    Payroll = payrollBase1.payrollId;
                }
            }
            addUserRepository.AddUser(UserName, LoginName, Password, IsAdmin, PhoneNumber, tempDateOfBirth, Country, Education, Gender, tempJoinDate, Role, Payroll, Facebook, Twitter, LinkedIn, Email, FileName,DepartmentId);
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
