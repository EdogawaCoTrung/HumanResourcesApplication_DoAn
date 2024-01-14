using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.Views.Admin;
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
        public ViewModelCommand AddBaseSalaryCommand {get;}
        public BaseSalaryViewModel() 
        {
            listPayrollBaseRepos = new ListPayrollBase();
            ListPayrollBase = listPayrollBaseRepos.ListPayrollBaseFunc();
            AddBaseSalaryCommand = new ViewModelCommand(ExecuteAddBaseSalaryCommand);
           
        }

        private void ExecuteAddBaseSalaryCommand(object? obj)
        {
            Payroll_Add payroll_Add = new Payroll_Add();
            payroll_Add.DataContext = new AddBaseSalaryViewModel();
            payroll_Add.ShowDialog();
            ListPayrollBase = listPayrollBaseRepos.ListPayrollBaseFunc();
        }
    }
}
