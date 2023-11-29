using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IDeleteDepartmentRepository
    {
        void DeleteDepartment(string? _departmentID, string? _departmentName, string? _head, int? _totalEmployees);   
    }
}
