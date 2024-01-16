using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Repositories.DepartmentRepo;
using HumanResourcesApplication_DoAn.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class ProjectMainViewModel:ViewModelBase
    {
        private List<Project>? listProject;
        private Project selectedProject;
        
        public List<Project> ListProject 
        { 
            get => listProject;
            set
            {
                listProject = value;
                OnPropertyChanged(nameof(listProject));
            }
        }
        public Project SelectedProject { get => selectedProject; set { selectedProject = value; OnPropertyChanged(nameof(SelectedProject)); } }
        //commands and interface
        public IListProjectRepository listProjectRepository;
        public IDeleteProjectRepository deleteProjectRepository;
        public ProjectMainViewModel()
        {
            listProject = new List<Project>();
            listProjectRepository = new ListProjectRepository();
            deleteProjectRepository = new DeleteProjectRepository();
            listProject = listProjectRepository.ListProject();
            AddProjectCommand = new ViewModelCommand(ExecuteAddProjectCommand);
            DeleteProjectCommand = new ViewModelCommand(ExecuteDeleteProjectCommand);
            ChangeProjectCommand = new ViewModelCommand(ExecuteChangeProjectCommand);
        }

        private void ExecuteChangeProjectCommand(object? obj)
        {
            Project_Change project_Change = new Project_Change();
            project_Change.DataContext = new ChangeProjectViewModel(selectedProject);
            project_Change.ShowDialog();
            ListProject = listProjectRepository.ListProject();  
        }

        private void ExecuteDeleteProjectCommand(object? obj)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa dự án này?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                deleteProjectRepository.Delete(SelectedProject.projectId);
            }
            ListProject = listProjectRepository.ListProject();
        }

        private void ExecuteAddProjectCommand(object? obj)

        {
            try
            {
                Project_Add project_Add = new Project_Add();
                project_Add.DataContext = new AddProjectViewModel();
                project_Add.ShowDialog();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ListProject = listProjectRepository.ListProject();
            }
            
        }

        public ViewModelCommand AddProjectCommand { get;}
  
        public ViewModelCommand DeleteProjectCommand { get;}
        public ViewModelCommand ChangeProjectCommand { get;}
        
    }
}
