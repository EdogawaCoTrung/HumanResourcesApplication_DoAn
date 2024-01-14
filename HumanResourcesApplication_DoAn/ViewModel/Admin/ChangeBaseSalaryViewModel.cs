using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class ChangeBaseSalaryViewModel:ViewModelBase
    {
        private PayrollBase payrollBase;
        private List<PayrollBase> roles = new List<PayrollBase>();
        private List<String> sourceRole;
        private string selectedRole;
        private double salary;
        public IListPayrollBase listPayrollBase;
        public IChangeBaseSalaryRepository changeBaseSalaryRepository;
        public PayrollBase PayrollBase { get => payrollBase; set { payrollBase = value; OnPropertyChanged(nameof(PayrollBase)); } }
        public ViewModelCommand ChangeCommand {  get;}
        public ViewModelCommand CancelCommand { get;}
        public List<PayrollBase> Roles { get => roles; set { roles = value; OnPropertyChanged(nameof(Roles)); } }

        public double Salary { get => salary; set { salary = value; OnPropertyChanged(nameof(Roles)); } }

        public List<string> SourceRole { get => sourceRole; set { sourceRole = value; OnPropertyChanged(nameof(SourceRole)); } }

        public string SelectedRole { get => selectedRole; set { selectedRole = value; OnPropertyChanged(nameof(SelectedRole)); } }

        public ChangeBaseSalaryViewModel(PayrollBase selectedPayrollBase)
        {
            this.payrollBase = selectedPayrollBase;
            selectedRole = selectedPayrollBase.role.roleName;
            SourceRole = new List<string>();
            Salary = selectedPayrollBase.salary;
            listPayrollBase = new ListPayrollBase();
            roles = listPayrollBase.ListPayrollBaseFunc();
            changeBaseSalaryRepository = new ChangeBaseSalaryRepository();
            ChangeCommand = new ViewModelCommand(ExecuteChangeCommand, CanExecuteChangeCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
            foreach(PayrollBase payrollBase in roles)
            {
                SourceRole.Add(payrollBase.role.roleName);
            }
        }

        private void ExecuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close(); 
        }

        private bool CanExecuteChangeCommand(object? obj)
        {
            return true;
        }

        private void ExecuteChangeCommand(object? obj)
        {
            foreach (PayrollBase payrollBaseTemp in roles)
            {
                if(SelectedRole == payrollBaseTemp.role.roleName)
                {
                    SelectedRole = payrollBaseTemp.role.roleId;
                    break;
                }
            }
            changeBaseSalaryRepository.ChangeBaseSalary(payrollBase.payrollId, SelectedRole, salary);
            Application.Current.MainWindow.Close();
        }
    }
}
