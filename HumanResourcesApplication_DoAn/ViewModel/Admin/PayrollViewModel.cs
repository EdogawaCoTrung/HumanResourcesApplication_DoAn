using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Views.Admin;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using Attendance = HumanResourcesApplication_DoAn.Model.Attendance;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class PayrollViewModel : ViewModelBase
    {
        private Payroll _selectedPayroll;
        private List<string> monthSource;
        private List<string> yearSource;
        private string selectedMonth;
        private string selectedYear;
        private PayrollMainViewViewModel mainView;
        public struct salarySta
        {
            public double? salary { get; set; }
            public string? departmentName { get; set; }
        };
        public ViewModelCommand AddPayrollCommand { get; }
        public IListPayrollRepository? payrollRepository { get; }
        private IListAttendanceRepository? attendanceRepository;
        private List<Payroll>? _payrolls;
        private List<salarySta> _salSta;
        private salarySta _top1;
        private salarySta _top2;
        private salarySta _top3;
        private salarySta _top4;
        private List<Attendance>? _listAttendance;
        public List<Payroll> payrolls
        {
            get => _payrolls; set
            {
                _payrolls = value;
                OnPropertyChanged(nameof(payrolls));
            }
        }
        public ViewModelCommand ShowInforSalary { get; }
        public List<Attendance> listAttendance { get => _listAttendance; set { _listAttendance = value; OnPropertyChanged(nameof(listAttendance)); } }

        public List<salarySta> salSta { get => _salSta; set { _salSta = value; OnPropertyChanged(nameof(salSta)); } }

        public PayrollMainViewViewModel MainView { get => mainView; set { mainView = value; OnPropertyChanged(nameof(MainView)); } }

        public List<string> MonthSource { get => monthSource; set { monthSource = value; OnPropertyChanged(nameof(MonthSource)); } }
        public List<string> YearSource { get => yearSource; set { yearSource = value; OnPropertyChanged(nameof(YearSource)); } }
        public salarySta Top1 { get => _top1; set { _top1 = value; OnPropertyChanged(nameof(Top1)); } }
        public salarySta Top2 { get => _top2; set { _top2 = value; OnPropertyChanged(nameof(Top2)); } }
        public salarySta Top3 { get => _top3; set { _top3 = value; OnPropertyChanged(nameof(Top3)); } }
        public salarySta Top4 { get => _top4; set { _top4 = value; OnPropertyChanged(nameof(Top4)); } }
        public Payroll SelectedPayroll { get => _selectedPayroll; set { _selectedPayroll = value; OnPropertyChanged(nameof(SelectedPayroll)); } }
        public string SelectedMonth
        {
            get => selectedMonth; set
            {
                selectedMonth = value;
                OnPropertyChanged(nameof(SelectedMonth));
                salSta.Clear();
                filterPayroll();
                filterSalarySta();
            }
        }
        public string SelectedYear
        {
            get => selectedYear; set
            {
                selectedYear = value;
                OnPropertyChanged(nameof(SelectedYear));
                salSta.Clear();
                filterPayroll();
                filterSalarySta();
            }
        }

        int convertTimespan(string _timeSpan)
        {
            int timeSpan = 0;
            timeSpan += int.Parse(_timeSpan[0].ToString()) * 10 + int.Parse(_timeSpan[1].ToString());
            return timeSpan;
        }

        void filterPayroll()
        {
            List<Payroll> temp = payrolls;
            for (int i = 0; i < temp.Count; i++)
            {
                int overtime = 0;
                int late = 0;
                int absence = 0;
                for (int j = 0; j < listAttendance.Count; j++)
                {
                    if (temp[i].user.userName == listAttendance[j].userId && ((DateOnly)listAttendance[j].date).Month.ToString() == SelectedMonth && ((DateOnly)listAttendance[j].date).Year.ToString() == SelectedYear)
                    {
                        if ((listAttendance[j].inTime - TimeSpan.Parse("07:00:00") > TimeSpan.Parse("00:30:00")) || (TimeSpan.Parse("17:00:00") - listAttendance[j].outTime > TimeSpan.Parse("00:30:00")))
                        {
                            late++;
                        }
                        else if (listAttendance[j].inTime == TimeSpan.Parse("00:00:00"))
                        {
                            absence++;
                        }
                        if (listAttendance[j].outTime - TimeSpan.Parse("17:00:00") > TimeSpan.Parse("00:00:00"))
                        {
                            overtime += convertTimespan((listAttendance[j].outTime - TimeSpan.Parse("17:00:00")).ToString());
                        }
                    }

                }
                temp[i].salary = Math.Round((double)(temp[i].salary - (double)(late * 0.005 * temp[i].salary) - (double)(absence * 0.05 * temp[i].salary) + (double)(overtime * 0.0075 * temp[i].salary)), 2);
            }
            payrolls = temp;
        }

        void filterSalarySta()
        {
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
                    double? sum = 0;
                    for (int j = 0; j < payrolls.Count; j++)
                    {
                        if (i!=j && payrolls[i].department.departmentName == payrolls[j].department.departmentName)
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
            Top1 = salSta[0];
            Top2 = salSta[1];
            Top3 = salSta[2];
            Top4 = salSta[3];
        }
        public PayrollViewModel(PayrollMainViewViewModel mainView)
        {
            this.mainView = mainView;
            payrollRepository = new ListPayrollRepository();
            payrolls = new List<Payroll>();
            listAttendance = new List<Attendance>();
            payrolls = payrollRepository.ListPayrolls();
            attendanceRepository = new ListAttendanceRepository();
            listAttendance = attendanceRepository.ListAttendance();
            ShowInforSalary = new ViewModelCommand(ExecuteShowInforSalaryCommand);
            salSta = new List<salarySta>();
            Top1 = new salarySta();
            Top2 = new salarySta();
            Top3 = new salarySta();
            Top4 = new salarySta();
            filterPayroll();
            filterSalarySta();
            MonthSource = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            YearSource = new List<string>() { };
            for (int i = 1980; i <= DateTime.Now.Year; i++)
            {
                YearSource.Add(i.ToString());
            }
        }

        private void ExecuteShowInforSalaryCommand(object? obj)
        {
            SalaryDetail salaryDetail = new SalaryDetail();
            salaryDetail.ShowDialog();
        }
    }
}
