using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class AttendanceViewModel : ViewModelBase
    {
        private IListAttendanceRepository? attendanceRepository;// lấy data từ Model 
        private IListUsersRepository? listUsers; // lấy user từ Model
        private List<Attendance>? listAttendance;
        private List<AttendanceForView>? _attendances;
        private int _totalEmployee;
        private int _attend;
        private int _lateAttend;
        private int _absence;
        private List<Department> _listDepartment;
        private string _selectedDepartment;
        private List<string> _sourceDepartment;
        private DateTime _startDate;
        private DateTime _endDate;
        public List<Attendance>? ListAttendance { get => listAttendance; set { listAttendance = value; OnPropertyChanged(nameof(ListAttendance)); } }
        public List<AttendanceForView>? Attendances { get => _attendances; set { _attendances = value; OnPropertyChanged(nameof(Attendances)); } }

        private ObservableCollection<Attendance> _lstAttendance = new ObservableCollection<Attendance>();
        public ObservableCollection<Attendance> LstAttendance
        {
            get { return _lstAttendance; }       
        }

        
        public int TotalEmployee { get => _totalEmployee; set { _totalEmployee = value; OnPropertyChanged(nameof(TotalEmployee)); } }
        public int Attend { get => _attend; set { _attend = value; OnPropertyChanged(nameof(Attend)); } }
        public int LateAttend { get => _lateAttend; set { _lateAttend = value; OnPropertyChanged(nameof(LateAttend)); } }
        public int Absence { get => _absence; set { _absence = value; OnPropertyChanged(nameof(Absence)); } }

        public List<Department> ListDepartment { get => _listDepartment; set { _listDepartment = value; OnPropertyChanged(nameof(ListDepartment)); } }
        public string SelectedDepartment { get => _selectedDepartment; set { _selectedDepartment = value; OnPropertyChanged(nameof(SelectedDepartment)); } }
        public List<string> SourceDepartment { get => _sourceDepartment; set { _sourceDepartment = value; OnPropertyChanged(nameof(SourceDepartment)); } }
        public DateTime StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); filter(); } }
        public DateTime EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); filter(); } }
        
        public IListDepartmentRepository departmentRepository;
        public void filter()
        { 
            List<AttendanceForView> temp = new List<AttendanceForView>();

            foreach(AttendanceForView attendance in Attendances)
            {

                if(DateOnly.FromDateTime(StartDate)<= attendance.date && attendance.date <= DateOnly.FromDateTime(EndDate))
                {
                    temp.Add(attendance);
                }
               
            }
            Attendances = temp; 
        }
        public AttendanceViewModel()
        {
            departmentRepository= new ListDepartmentRepository();
            ListDepartment = new List<Department>();
            ListDepartment = departmentRepository.ListDepartment();
            SourceDepartment = new List<string>();
            foreach(Department department in ListDepartment)
            {
                SourceDepartment.Add(department.departmentName);
            }
            attendanceRepository = new ListAttendanceRepository();
            listAttendance = new List<Attendance>();
            listAttendance = attendanceRepository.ListAttendance();
            listUsers = new ListUsersRepository();
            Attendances = new List<AttendanceForView>();
            TotalEmployee = listUsers.ListUsers() != null ? listUsers.ListUsers().Count : 0;
            StartDate= DateTime.Now;   
            EndDate = DateTime.Now.AddDays(1);  
            LateAttend = 0;
            Attend = 0;
            Absence = 0;
            for(int i = 0; i < listAttendance.Count; i++)
            {
                for(int j = i + 1; j < listAttendance.Count; j++)
                {
                    if(listAttendance[i].date < listAttendance[j].date)
                    {
                        Attendance? temp = new Attendance();
                        temp = listAttendance[i];
                        listAttendance[i] = listAttendance[j];
                        listAttendance[j] = temp;
                    }
                }
            }
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
                if (listAttendance[i].inTime - TimeSpan.Parse("07:00:00") > TimeSpan.Parse("00:00:00"))
                    Attendances[i].inTime = listAttendance[i].inTime.ToString() + " (" + (listAttendance[i].inTime - TimeSpan.Parse("07:00:00")) + ")";
                else
                    Attendances[i].inTime = listAttendance[i].inTime.ToString();
                if (TimeSpan.Parse("17:00:00") - listAttendance[i].outTime > TimeSpan.Parse("00:00:00"))
                    Attendances[i].outTime = listAttendance[i].outTime.ToString() + " (" + (TimeSpan.Parse("17:00:00") - listAttendance[i].outTime) + ")";
                else
                    Attendances[i].outTime = listAttendance[i].outTime.ToString();
                Attendances[i].hours = listAttendance[i].hours.ToString();
                Attendances[i].status = listAttendance[i].status;
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
