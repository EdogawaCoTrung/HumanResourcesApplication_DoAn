using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IChangeProjectRepository
    {
        public void ChangeProject(string projectId, string projectName, string startDate, string endDate, string projectManager, string departmentName, string numberOfMember, string description, string revenue, string type);
    }
}
