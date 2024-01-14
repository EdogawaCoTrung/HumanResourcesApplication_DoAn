using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class PayrollInforViewModel:ViewModelBase
    {
        private Payroll payroll;
        private double? baseSalary;
        private List<Payroll> listPayroll;
        private List<Payroll> listPayrollBase;
        public Payroll Payroll { get => payroll; set { payroll = value; OnPropertyChanged(nameof(Payroll)); } }
        public List<Payroll> ListPayroll { get => listPayroll; set { listPayroll = value; OnPropertyChanged(nameof(ListPayroll)); } }

        public double? BaseSalary { get => baseSalary; set { baseSalary = value; OnPropertyChanged(nameof(BaseSalary)); } }

        public List<Payroll> ListPayrollBase { get => listPayrollBase; set { listPayrollBase = value; OnPropertyChanged(nameof(ListPayrollBase)); } }
        public IListPayrollRepository listPayrollRepository;
        public PayrollInforViewModel(Payroll SelectedItem) 
        {
            this.payroll = SelectedItem;
            listPayrollRepository = new ListPayrollRepository();
            listPayrollBase = listPayrollRepository.ListPayrolls();
            foreach (Payroll payrollvar in listPayrollBase)
            {
                if(payroll.payrollId==payrollvar.payrollId) 
                {
                    payroll.salary = payrollvar.salary;
                    break;
                }
            }
            ListPayroll = new List<Payroll>() { Payroll };  

        }
    }
}
