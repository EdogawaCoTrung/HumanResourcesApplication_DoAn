using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using Org.BouncyCastle.Math.EC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class PayrollViewModel:ViewModelBase
    {
        public IListPayrollRepository? payrollRepository { get; }
        private IListAttendanceRepository? attendanceRepository;
        public ViewModelCommand CaculateCommand { get; }
        private List<Payroll>? _payrolls;
        private List<Attendance>? _listAttendance;
        private double? userBasePayroll { get; set; }
        public List<Payroll> Payrolls
        {
            get => _payrolls; set
            {
                _payrolls = value;
                OnPropertyChanged(nameof(Payrolls));
            }
        }
        public List<Attendance> listAttendance { get => _listAttendance; set { _listAttendance = value; OnPropertyChanged(nameof(listAttendance)); } }

        int convertTimespan(string _timeSpan)
        {
            int timeSpan = 0;
            timeSpan += int.Parse(_timeSpan[0].ToString()) * 10 + int.Parse(_timeSpan[1].ToString());
            return timeSpan;
        }

        void filterPayroll()
        {
            for(int year = DateOnly.FromDateTime(DateTime.Now).Year; year >= 2020; year--) {
                for(int month = 12; month >= 1; month--) {
                    if (year == 2024 && month > 1) continue;
                    int overtime = 0;
                    int late = 0;
                    int absence = 0;
                    for (int i = 0; i < listAttendance.Count; i++)
                    {
                        if (listAttendance[i].userId.userName == MyApp.currentUser.userName && ((DateOnly)listAttendance[i].date).Month == month && ((DateOnly)listAttendance[i].date).Year == year)
                        {
                            if (listAttendance[i].status == "Absent")
                            {
                                absence++;
                            }
                            else if ((listAttendance[i].inTime - TimeSpan.Parse("07:00:00") > TimeSpan.Parse("00:30:00")) || (TimeSpan.Parse("17:00:00") - listAttendance[i].outTime > TimeSpan.Parse("00:30:00")))
                            {
                                late++;
                            }
                            if (listAttendance[i].outTime - TimeSpan.Parse("17:00:00") > TimeSpan.Parse("00:00:00"))
                            {
                                overtime += convertTimespan((listAttendance[i].outTime - TimeSpan.Parse("17:00:00")).ToString());
                            }
                        }
                    }
                    Payroll temp = new Payroll();
                    temp.stt = (Payrolls.Count + 1).ToString();
                    temp.date = month.ToString() + "/" + year.ToString();
                    temp.salary = Math.Round((double)(userBasePayroll - (double)(late * 0.005 * userBasePayroll) - (double)(absence * 0.05 * userBasePayroll) + (double)(overtime * 0.0075 * userBasePayroll)), 2);
                    Payrolls.Add(temp);
                }
            }
        }


        public PayrollViewModel()
        {
            payrollRepository = new ListPayrollRepository();
            attendanceRepository = new ListAttendanceRepository();
            Payrolls = new List<Payroll>();
            listAttendance = new List<Attendance>();
            Payrolls = payrollRepository.ListPayrolls();
            listAttendance = attendanceRepository.ListAttendance();
            for(int i = 0; i < Payrolls.Count; i++)
            {
                if (Payrolls[i].user.userName == MyApp.currentUser.userName)
                    userBasePayroll = Payrolls[i].salary;
            }
            Payrolls.Clear();
            filterPayroll();
        }
    }
}
