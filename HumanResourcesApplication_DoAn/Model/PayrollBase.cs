using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class PayrollBase
    {
        public string payrollId { get; set; }
        public Role role { get; set; }
        public double salary { get; set; }
        public PayrollBase() 
        {
            role = new Role();  
        }
    }
}
