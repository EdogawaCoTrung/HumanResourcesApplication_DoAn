using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class Department
    {
        public string departmentId { get; set; }
        public string departmentName { get; set; }
        public string head { get; set; }
        public int totalEmployees { get; set; }
    }
}
