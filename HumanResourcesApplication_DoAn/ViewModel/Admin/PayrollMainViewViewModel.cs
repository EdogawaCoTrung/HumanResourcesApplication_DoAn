using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{

    public class PayrollMainViewViewModel:ViewModelBase
    {
        ViewModelBase _currentPayrollChildView;
        EmployeeAllViewModel _payrollAllViewModel;
        EmployeeViewViewModel _baseSalaryiewModel;

        public ViewModelBase CurrentPayrollChildView { get => _currentPayrollChildView; set => _currentPayrollChildView = value; }
        public EmployeeAllViewModel PayrollAllViewModel { get => _payrollAllViewModel; set => _payrollAllViewModel = value; }
        public EmployeeViewViewModel BaseSalaryiewModel { get => _baseSalaryiewModel; set => _baseSalaryiewModel = value; }
    }

}
