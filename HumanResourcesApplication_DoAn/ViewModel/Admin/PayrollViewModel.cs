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
using Attendance = HumanResourcesApplication_DoAn.Model.Attendance;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class PayrollViewModel : ViewModelBase
    {
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
        private List<Attendance>? _listAttendance;
        public List<Payroll> payrolls { get => _payrolls; set { _payrolls = value; OnPropertyChanged(nameof(payrolls)); } }
        public List<Attendance> listAttendance { get => _listAttendance; set { _listAttendance = value; OnPropertyChanged(nameof(listAttendance)); } }

        public List<salarySta> salSta { get => _salSta; set { _salSta = value; OnPropertyChanged(nameof(salSta)); } }

        public PayrollMainViewViewModel MainView { get => mainView; set { mainView = value; OnPropertyChanged(nameof(MainView)); } }

        public PayrollViewModel(PayrollMainViewViewModel mainView)
        int convertTimespan(string _timeSpan)
        {
            int timeSpan = 0;
            timeSpan += int.Parse(_timeSpan[0].ToString()) * 10 + int.Parse(_timeSpan[1].ToString());
            return timeSpan;
        }
        public PayrollViewModel()
        {
            this.mainView = mainView;
            payrollRepository = new ListPayrollRepository();
            payrolls = new List<Payroll>();
            listAttendance = new List<Attendance>();
            payrolls = payrollRepository.ListPayrolls();
            attendanceRepository = new ListAttendanceRepository();
            listAttendance = attendanceRepository.ListAttendance();
            salSta = new List<salarySta>();
            for (int i = 0; i < payrolls.Count; i++)
            {
                int overtime = 0;
                int late = 0;
                int absence = 0;
                for (int j = 0; j < listAttendance.Count; j++)
                {
                    if (payrolls[i].user.userName == listAttendance[j].userId && ((DateOnly)listAttendance[j].date).Month == DateOnly.FromDateTime(DateTime.Now).Month && ((DateOnly)listAttendance[j].date).Year == DateOnly.FromDateTime(DateTime.Now).Year)
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
                payrolls[i].salary = payrolls[i].salary - (double)(late * 0.005 * payrolls[i].salary) - (double)(absence * 0.05 * payrolls[i].salary) + (double)(overtime * 0.0075 * payrolls[i].salary);
            }
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
            payrollView.DataContext = addPayrollViewModel;
            payrollView.ShowDialog();
        }
    }
}
