using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IChangeDepartmentRepository
    {
        public void ChangeDepartment( string?departmentID, string? departmentName, string? head, int? totalEmployees);
    }
}
