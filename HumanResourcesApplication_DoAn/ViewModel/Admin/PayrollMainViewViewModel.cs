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
        PayrollViewModel _payrollAllViewModel;
        BaseSalaryViewModel _baseSalaryiewModel;


        public ViewModelBase CurrentPayrollChildView { get => _currentPayrollChildView; set { _currentPayrollChildView = value; OnPropertyChanged(nameof(CurrentPayrollChildView)); } }
        public PayrollViewModel PayrollAllViewModel { get => _payrollAllViewModel; set { _payrollAllViewModel = value; OnPropertyChanged(nameof(PayrollAllViewModel)); } }
        public BaseSalaryViewModel BaseSalaryiewModel { get => _baseSalaryiewModel; set { _baseSalaryiewModel = value; OnPropertyChanged(nameof(BaseSalaryiewModel)); } }
        public ViewModelCommand ShowPayrollAllCommand { get; }
        public ViewModelCommand ShowBaseSalaryCommand { get; }
        public PayrollMainViewViewModel()
        {

            ShowPayrollAllCommand = new ViewModelCommand(ExecuteShowPayrollAllCommand);
            ShowBaseSalaryCommand = new ViewModelCommand(ExecuteShowBaseSalaryCommand);
            PayrollAllViewModel = new PayrollViewModel(this);
            _currentPayrollChildView = PayrollAllViewModel;
            ExecuteShowPayrollAllCommand(null);
        }

        private void ExecuteShowBaseSalaryCommand(object? obj)
        {
            if(_baseSalaryiewModel == null)
            { 
                _baseSalaryiewModel = new BaseSalaryViewModel();
            }
            CurrentPayrollChildView = _baseSalaryiewModel;
            PayrollAllViewModel = new PayrollViewModel(this);
        }

        private void ExecuteShowPayrollAllCommand(object? obj)
        {
            CurrentPayrollChildView= PayrollAllViewModel;
        }
    }

}
