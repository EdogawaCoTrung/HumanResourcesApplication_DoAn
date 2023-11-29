using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HumanResourcesApplication_DoAn.Model
{
    public interface IAddDepertmentRepository
    {
        public void AddDepartment(string? _departmentName, string? _head, int? _totalEmployee);
    }
}
