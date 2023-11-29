using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.Views.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesApplication_DoAn.Model;
using System.Windows.Input;
using System.Windows;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class EmployeeViewViewModel : ViewModelBase
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
