using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class Attendance
    {
        public string? attendenceId { get; set; }
        public string? userId { get; set; }
        public DateOnly? date { get; set; }
        public TimeSpan? inTime { get; set; }
        public TimeSpan? outTime { get; set; }
        public TimeSpan? hours { get; set; }
        public string? status { get; set; }
    }
}
