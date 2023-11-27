using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class AttendanceViewModel : ViewModelBase
    {
        private IListAttendanceRepository? attendanceRepository;
        private IListUsersRepository? listUsers;
        private List<Attendance>? listAttendance;
        private List<AttendanceForView>? _attendances;
        private int _totalEmployee;
        private int _attend;
        private int _lateAttend;
        private int _absence;
        public List<Attendance>? ListAttendance { get => listAttendance; set { listAttendance = value; OnPropertyChanged(nameof(ListAttendance)); } }
        public List<AttendanceForView>? Attendances { get => _attendances; set { _attendances = value; OnPropertyChanged(nameof(Attendances)); } }

        public int TotalEmployee { get => _totalEmployee; set { _totalEmployee = value; OnPropertyChanged(nameof(TotalEmployee)); } }
        public int Attend { get => _attend; set { _attend = value; OnPropertyChanged(nameof(Attend)); } }
        public int LateAttend { get => _lateAttend; set { _lateAttend = value; OnPropertyChanged(nameof(LateAttend)); } }
        public int Absence { get => _absence; set { _absence = value; OnPropertyChanged(nameof(Absence)); } }


        public AttendanceViewModel()
        {
            attendanceRepository = new ListAttendanceRepository();
            listAttendance = new List<Attendance>();
            listAttendance = attendanceRepository.ListAttendance();
            listUsers = new ListUsersRepository();
            Attendances = new List<AttendanceForView>();
            TotalEmployee = listUsers.ListUsers() != null ? listUsers.ListUsers().Count : 0;
            LateAttend = 0;
            Attend = 0;
            Absence = 0;
            for(int i = 0; i < listAttendance.Count; i++)
            {
                if (listAttendance[i].date == DateOnly.FromDateTime(DateTime.Now))
                {
                    if (listAttendance[i].status == "Present")
                    {
                        Attend++;
                        if (listAttendance[i].inTime > TimeSpan.Parse("07:00:00"))
                            LateAttend++;
                    }
                }
                AttendanceForView attendanceForView = new AttendanceForView();
                Attendances.Add(attendanceForView);
                Attendances[i].userId = listAttendance[i].userId;
                Attendances[i].date = listAttendance[i].date;
                Attendances[i].inTime = listAttendance[i].inTime.ToString();
                Attendances[i].outTime = listAttendance[i].outTime.ToString();
                Attendances[i].hours = listAttendance[i].hours.ToString();
                Attendances[i].hours = listAttendance[i].status;
                if (listAttendance[i].inTime.ToString() == "00:00:00")
                    Attendances[i].inTime = "--:--:--";
                if (listAttendance[i].outTime.ToString() == "00:00:00")
                    Attendances[i].outTime = "--:--:--";
                if (listAttendance[i].hours.ToString() == "00:00:00")
                    Attendances[i].hours = "--:--:--";
            }
            Absence = TotalEmployee - Attend;
        }
    }
}
