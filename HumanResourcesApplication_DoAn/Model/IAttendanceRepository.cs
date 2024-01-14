using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IAttendanceRepository
    {
        List<Attendance?> GetAttendanceByUserId(string? userId);
        void AddAttendance(string? userId);
    }
}
