using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesApplication_DoAn.Model;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    internal class EmployeeViewViewModel:ViewModelBase
    {
        private EmployeeMainViewViewModel  mainViewModel;
        private EmployeeAllViewModel allViewModel;
        public EmployeeViewViewModel()
        {

        }
        public EmployeeViewViewModel(EmployeeMainViewViewModel mainViewModel, EmployeeAllViewModel allViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.allViewModel = allViewModel;
        }
    }
}
