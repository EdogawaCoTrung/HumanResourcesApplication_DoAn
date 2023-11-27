using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class AttendanceForView
    {
        public string? attendenceId { get; set; }
        public string? userId { get; set; }
        public DateOnly? date { get; set; }
        public string? inTime { get; set; }
        public string? outTime { get; set; }
        public string? hours { get; set; }
        public string? status { get; set; }
    }
}
