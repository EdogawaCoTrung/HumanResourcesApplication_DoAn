using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
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
        }
    }
}
