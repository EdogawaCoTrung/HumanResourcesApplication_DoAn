using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(User userModel);
        void Edit(User userModel);
        void Remove(int id);
        User GetById(int id);
        User GetByLoginName(string loginName);
        IEnumerable<User> GetByAll();

    }
}
