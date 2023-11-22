using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class Attendence
    {
        public string attendenceId { get; set; }
        public string userId { get; set; }
        public string date { get; set; }
        public string inTime { get; set; }
        public string outTime { get; set; }
        public bool status { get; set; }
    }
}
