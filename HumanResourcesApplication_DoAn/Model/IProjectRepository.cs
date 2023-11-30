using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IProjectRepository
    {
        void Change(string projectId);
        void Remove(string projectId);
        User GetById(string projectId);
        IEnumerable<User> GetByAll();
    }
}
