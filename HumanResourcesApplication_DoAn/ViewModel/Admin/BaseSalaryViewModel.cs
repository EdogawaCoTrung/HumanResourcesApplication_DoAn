using HumanResourcesApplication_DoAn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class BaseSalaryViewModel:ViewModelBase
    {
        private List<PayrollBase> listPayrollBase;
        private PayrollBase selectedItem;
        public IListPayrollBase listPayrollBaseRepos;
        public List<PayrollBase> ListPayrollBase { get => listPayrollBase; set { listPayrollBase = value; OnPropertyChanged(nameof(ListPayrollBase)); } }

        public PayrollBase SelectedItem { get => selectedItem; set { selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); } }

        public BaseSalaryViewModel() 
        { }
    }
}
