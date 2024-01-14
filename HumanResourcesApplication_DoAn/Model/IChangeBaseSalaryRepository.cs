using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IChangeBaseSalaryRepository
    {
        public void ChangeBaseSalary(string payrollId,string roleId, double salary);
    }
}
