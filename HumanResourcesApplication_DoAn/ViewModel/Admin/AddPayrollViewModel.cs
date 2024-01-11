using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class AddPayrollViewModel : ViewModelBase
    {
        PayrollHistory _payrollHistory;
        public IAddPayrollHistoryRepository addPayrollHistory;
        private string _startDate;
        private string _endDate;
        public PayrollHistory PayrollHistory { get => _payrollHistory; set { _payrollHistory = value; OnPropertyChanged(nameof(PayrollHistory)); } }
        public ViewModelCommand AddCommand { get; }
        public ViewModelCommand CancelCommand { get; }
        public string StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }
        public string EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }

        public AddPayrollViewModel()
        {
            _payrollHistory = new PayrollHistory();
            addPayrollHistory = new AddPayrollHistoryRepository();
            AddCommand = new ViewModelCommand(ExcuteAddCommand, CanExcuteAddCommand);
            CancelCommand = new ViewModelCommand(ExcuteCancelCommand);

        }

        private bool CanExcuteAddCommand(object? obj)
        {
            bool IsValid = true;
            if (_payrollHistory.userId == "" || _payrollHistory.userId == null)
            {
                IsValid = false;
            }
            else if (_payrollHistory.payrollId == "" || _payrollHistory.payrollId == null) { IsValid = false; }
            else if (StartDate == null || StartDate == "") { IsValid = false; }
            else if (EndDate == null ||EndDate=="") { IsValid = false; }
            return IsValid;
        }

        private void ExcuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close();
        }

        private void ExcuteAddCommand(object? obj)
        {
            addPayrollHistory.AddPayrollHistory(PayrollHistory.userId, PayrollHistory.payrollId, DateOnly.Parse(StartDate), DateOnly.Parse(EndDate));
            Application.Current.MainWindow.Close();
        }
    }
}
