using HumanResourcesApplication_DoAn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class ProjectRepository : RepositoryBase, IProjectRepository
    {
        public void Change(string projectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetByAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(string projectId)
        {
            throw new NotImplementedException();
        }

        public void Remove(string projectId)
        {
            throw new NotImplementedException();
        }
    }
}
