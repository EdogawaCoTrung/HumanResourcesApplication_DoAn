using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var command = new MySqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM USERS WHERE LOGINNAME=@loginName AND PASSWORD=@password";
                command.Parameters.Add("@loginName", MySqlDbType.VarString).Value = credential.UserName;
                command.Parameters.Add("@password", MySqlDbType.VarString).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }


        public void Edit(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetByAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByLoginName(string loginName)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
