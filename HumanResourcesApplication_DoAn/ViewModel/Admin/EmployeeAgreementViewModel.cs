using HumanResourcesApplication_DoAn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class EmployeeAgreementViewModel : ViewModelBase
    {
        private Contract? _userInfor;
        public Contract? userInfor { get => _userInfor; set { _userInfor = value; OnPropertyChanged(nameof(userInfor)); } }
        public EmployeeAgreementViewModel(Contract? selectedItem)
        {
            userInfor = selectedItem;
        }

    }
}
