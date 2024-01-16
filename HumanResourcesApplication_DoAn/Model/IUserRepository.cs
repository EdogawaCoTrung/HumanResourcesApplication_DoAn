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
        void Add(User user);
        void Edit(User user);
        void Remove(string? userid);
        User GetById(string id);
        User GetByLoginName(string loginName);
        IEnumerable<User> GetByAll();

    }
}
