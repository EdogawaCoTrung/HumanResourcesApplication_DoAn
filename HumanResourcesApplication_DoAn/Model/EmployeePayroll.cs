using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class EmployeePayroll
    {
        public User User { get; set; }
        public Payroll Payroll { get; set; }
        public PayrollHistory PayrollHistory { get; set; }
        public EmployeePayroll()
        {
            User = new User();
            Payroll = new Payroll();
            PayrollHistory = new PayrollHistory();
        }
    }
}
