using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Views.Admin;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class PayrollViewModel : ViewModelBase
    {
        private PayrollMainViewViewModel mainView;
        public struct salarySta {
            public int? salary { get; set; }
            public string? departmentName { get; set; }
        };
        public ViewModelCommand AddPayrollCommand { get; }
        public IListPayrollRepository? payrollRepository { get;}
        private List<Payroll>? _payrolls;
        private List<salarySta> _salSta;
        public List<Payroll> payrolls { get => _payrolls; set { _payrolls = value; OnPropertyChanged(nameof(payrolls)); } }

        public List<salarySta> salSta { get => _salSta; set { _salSta = value; OnPropertyChanged(nameof(salSta)); } }

        public PayrollMainViewViewModel MainView { get => mainView; set { mainView = value; OnPropertyChanged(nameof(MainView));} }

        public PayrollViewModel(PayrollMainViewViewModel mainView)
        {
            this.mainView = mainView;
            payrollRepository = new ListPayrollRepository();
            payrolls = new List<Payroll>();
            payrolls = payrollRepository.ListPayrolls();
            salSta = new List<salarySta>();
            for (int i = 0; i < payrolls.Count; i++)
            {
                bool check = false;
                for (int j = 0; j < salSta.Count; j++)
                {
                    if (salSta != null && payrolls[i].department.departmentName == salSta[j].departmentName)
                    {
                        check = true;
                    }
                }
                if (!check)
                {
                    salarySta temp = new salarySta();
                    int? sum = 0;
                    for (int j = 0; j < payrolls.Count; j++)
                    {
                        if (payrolls[i].department.departmentName == payrolls[j].department.departmentName)
                        {
                            sum += payrolls[i].salary;
                        }
                    }
                    temp.departmentName = payrolls[i].department.departmentName;
                    temp.salary = sum;
                    salSta.Add(temp);
                }
            }
            for (int i = 0; i < salSta.Count - 1; i++)
            {
                for (int j = i + 1; j < salSta.Count; j++)
                {
                    if (salSta[i].salary < salSta[j].salary)
                    {
                        salarySta temp = salSta[i];
                        salSta[i] = salSta[j];
                        salSta[j] = temp;
                    }
                }
            }
            AddPayrollCommand = new ViewModelCommand(ExcutePayrollCommand);
        }

        private void ExcutePayrollCommand(object? obj)
        {
            Payroll_Add payrollView = new Payroll_Add();
            AddPayrollViewModel addPayrollViewModel = new AddPayrollViewModel();
            payrollView.DataContext= addPayrollViewModel;
            payrollView.ShowDialog();
        }
    }
}
