using HumanResourcesApplication_DoAn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class ContractViewModel:ViewModelBase
    {
        private User _user;
        public User User { get => _user; set { _user = value; OnPropertyChanged(nameof(User)); } }
        public ContractViewModel( User currentUser) 
        {
            User = currentUser;
        }    }
}
