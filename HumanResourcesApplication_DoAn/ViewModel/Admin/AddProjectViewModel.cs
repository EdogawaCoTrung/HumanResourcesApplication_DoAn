using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
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

    public class AddProjectViewModel: ViewModelBase
    {
        private string? projectName;
        private DateTime startDate;
        private DateTime endDate;
        private List<string> projectManagerSource;
        private string selectedProjectManager;
        private string projectManagerId;
        
        private List<string>? departmentSource;
        private string selectedDepartment;
        private string departmentId;
        private string? numOfMember;
        private string? description;
        private string? revenue;
        private string? type;
        private List<User> users;
        private List<Department> departments;
        private List<string> typeSource;
        private string selectedSource;
        private string tempStartDate;
        private string tempEndDate;
        public string? ProjectName { get => projectName; set { projectName = value; OnPropertyChanged(nameof(ProjectName)); } }
        public DateTime StartDate { get => startDate; set { startDate = value; OnPropertyChanged(nameof(StartDate)); } }
        public DateTime EndDate { get => endDate; set { endDate = value; OnPropertyChanged(nameof(EndDate)); } }
        public List<string>? ProjectManagerSource { get => projectManagerSource; set { projectManagerSource = value; OnPropertyChanged(nameof(ProjectManagerSource)); } }
        public List<string>? DepartmentSource {get => departmentSource; set { departmentSource = value; OnPropertyChanged(nameof(DepartmentSource));}}
        public string? NumOfMember { get => numOfMember; set { numOfMember = value; OnPropertyChanged(nameof(NumOfMember)); } }
        public string? Description { get => description; set { description = value; OnPropertyChanged(nameof(Description)); } }
        public string? Revenue { get => revenue; set { revenue = value; OnPropertyChanged(nameof(Revenue)); } }
        public string? Type { get => type; set { type = value; OnPropertyChanged(nameof(Type)); } }
        public List<User> Users { get => users; set { users = value; OnPropertyChanged(nameof(Users)); } }
        public List<Department> Departments { get => departments; set { departments = value; OnPropertyChanged(nameof(Departments)); } }
        public List<string> TypeSource { get => typeSource; set { typeSource = value; OnPropertyChanged(nameof(TypeSource)); } }
        public string TempStartDate { get => tempStartDate; set { tempStartDate = value; OnPropertyChanged(nameof(TempStartDate)); } }
        public string ProjectManagerId { get => projectManagerId; set { projectManagerId = value; OnPropertyChanged(nameof(ProjectManagerId)); } }
        public string DepartmentId { get => departmentId; set { departmentId = value; OnPropertyChanged(nameof(DepartmentId)); } }
        public string SelectedProjectManager { get => selectedProjectManager; set { selectedProjectManager = value; OnPropertyChanged(nameof(SelectedProjectManager)); } }
        public string SelectedSource { get => selectedSource; set { selectedSource = value; OnPropertyChanged(nameof(SelectedSource)); } }
        public string TempEndDate { get => tempEndDate; set { tempEndDate = value; OnPropertyChanged(nameof(TempEndDate)); } }
        public string SelectedDepartment { get => selectedDepartment; set { selectedDepartment = value; OnPropertyChanged(nameof(SelectedDepartment)); } }

        public IListUsersRepository userRepository;
        public IListDepartmentRepository departmentRepository;
        public ChangeDate changeDate;
        public AddProjectViewModel () 
        {
            userRepository = new ListUsersRepository();
            departmentRepository = new ListDepartmentRepository();
            users = userRepository.ListUsers();
            Departments = departmentRepository.ListDepartment(); 
            ProjectManagerSource = new List<string>();
            DepartmentSource = new List<string> { };
            changeDate = new ChangeDate();  
            foreach(User user in users)
            {
                ProjectManagerSource.Add(user.userName);
            }
            foreach (Department department in Departments)
            {
                DepartmentSource.Add(department.departmentName);
            }
            TypeSource = new List<string>() { "Diret", "Organic", "Referral" };
            AddProjectCommand = new ViewModelCommand(ExecuteAddProjectCommand, CanExecuteAddProjectCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);

            
        }

        private void ExecuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close();
        }

        private bool CanExecuteAddProjectCommand(object? obj)
        {
            return true;
        }

        private void ExecuteAddProjectCommand(object? obj)
        {
            foreach(User user in users)
            {
                if(user.userName == SelectedProjectManager)
                {
                    projectManagerId = user.userId;
                    break;
                }
            }
            TempStartDate = changeDate.ChangeDateFormat(StartDate);
            MessageBox.Show(projectManagerId);
        }
        public ViewModelCommand AddProjectCommand { get; }
        public ViewModelCommand CancelCommand { get; }
       
    }
}
