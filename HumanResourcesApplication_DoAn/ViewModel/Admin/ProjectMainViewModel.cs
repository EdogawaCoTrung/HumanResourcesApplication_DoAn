using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class ProjectMainViewModel:ViewModelBase
    {
        private List<Project>? listProject;
        
        public List<Project> ListProject 
        { 
            get => listProject;
            set
            {
                listProject = value;
                OnPropertyChanged(nameof(listProject));
            }
        }
        //commands and interface
        public IListProjectRepository listProjectRepository;
        public ProjectMainViewModel()
        {
            listProject = new List<Project>();
            listProjectRepository = new ListProjectRepository();
            listProject = listProjectRepository.ListProject();
            AddProjectCommand = new ViewModelCommand(ExecuteAddProjectCommand);
        }

        private void ExecuteAddProjectCommand(object? obj)

        {
            AddProjectViewModel addProjectViewModel = new AddProjectViewModel();   
            Project_Add project_Add = new Project_Add();
            project_Add.DataContext = addProjectViewModel;
            project_Add.ShowDialog();
        }

        public ViewModelCommand AddProjectCommand { get;}
  
        public ViewModelCommand DeleteProjectCommand { get;}
        public ViewModelCommand EditProjectCommand { get;}
    }
}
