using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class AttendanceViewModel: ViewModelBase
    {
        private List<Attendance?> _attendances;
        private IAttendanceRepository _attendanceRepository;

        public List<Attendance?> attendances { get => _attendances; set { _attendances = value; OnPropertyChanged(nameof(attendances)); } }

        public AttendanceViewModel()
        {
            _attendanceRepository = new AttendanceRepository();
            attendances = new List<Attendance?>();
            attendances = _attendanceRepository.GetAttendanceByUserId(MyApp.currentUser.userId);
        }

    }
}
