using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IAddProjectRepository
    {
        void AddProject(string projectName, string startDate, string endDate, string projectManager, string departmentName, string numberOfMember, string description, string revenue, string type);
    }
}
