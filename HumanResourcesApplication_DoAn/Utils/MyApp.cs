using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.ViewModel.EmployeeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Utils
{
    internal class MyApp
    {
        public static User currentUser { get; set; }
        public static MainViewViewModel mainViewModelEmployee { get; set; }
    }
}
