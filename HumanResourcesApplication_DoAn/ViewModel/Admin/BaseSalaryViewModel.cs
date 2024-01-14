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
        public ViewModelCommand ChangeBaseSalaryCommand {  get; }
        public BaseSalaryViewModel() 
        {
            listPayrollBaseRepos = new ListPayrollBase();
            ListPayrollBase = listPayrollBaseRepos.ListPayrollBaseFunc();
            AddBaseSalaryCommand = new ViewModelCommand(ExecuteAddBaseSalaryCommand);
            ChangeBaseSalaryCommand = new ViewModelCommand(ExecuteChangeBaseSalaryCommand);


        }

        private void ExecuteChangeBaseSalaryCommand(object? obj)
        {
            BaseSalary_Change baseSalary_Change = new BaseSalary_Change();
            baseSalary_Change.DataContext = new ChangeBaseSalaryViewModel(SelectedItem);
            baseSalary_Change.ShowDialog();
            ListPayrollBase = listPayrollBaseRepos.ListPayrollBaseFunc();
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
