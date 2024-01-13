using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class AttendanceViewModel: ViewModelBase
    {
        private List<Attendance?> _attendances;
        private IAttendanceRepository _attendanceRepository;
        public ICommand AttendanceCommand { get; }

        public List<Attendance?> attendances { get => _attendances; set { _attendances = value; OnPropertyChanged(nameof(attendances)); } }

        public AttendanceViewModel()
        {
            AttendanceCommand = new ViewModelCommand(ExecuteAttendanceCommand, CanExecuteAttendanceCommand);

            _attendanceRepository = new AttendanceRepository();
            attendances = new List<Attendance?>();
            attendances = _attendanceRepository.GetAttendanceByUserId(MyApp.currentUser.userId);
            for (int i = 0; i < attendances.Count; i++)
            {
                for (int j = i + 1; j < attendances.Count; j++)
                {
                    if (attendances[i].date < attendances[j].date)
                    {
                        Attendance? temp = new Attendance();
                        temp = attendances[i];
                        attendances[i] = attendances[j];
                        attendances[j] = temp;
                    }
                }
            }
        }

        private void ExecuteAttendanceCommand(object? obj)
        {
            _attendanceRepository.AddAttendance(MyApp.currentUser.userId);
            attendances = _attendanceRepository.GetAttendanceByUserId(MyApp.currentUser.userId);
        }
        private bool CanExecuteAttendanceCommand(object? obj)
        {
            return true;
        }
    }
}
