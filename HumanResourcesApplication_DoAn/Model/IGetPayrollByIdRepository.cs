using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IGetPayrollByIdRepository
    {
        public List<EmployeePayroll> GetPayrollById(string userId);
    }
}
