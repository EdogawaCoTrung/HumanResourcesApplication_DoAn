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
            if (connection.State.ToString() == "Closed")
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM USERS JOIN ROLE ON ROLE.ROLE_ID = USERS.ROLE_ID JOIN DEPARTMENT ON USERS.DEPARTMENT_ID = DEPARTMENT.DEPARTMENT_ID JOIN EDUCATION ON USERS.EDUCATION_ID = EDUCATION.EDUCATION_ID JOIN COUNTRY ON USERS.COUNTRY_ID = COUNTRY.COUNTRY_ID JOIN PAYROLL ON USERS.PAYROLL_ID = PAYROLL.PAYROLL_ID WHERE LOGINNAME=@loginName";
            command.Parameters.Add("@loginName", MySqlDbType.VarString).Value = loginName;
            MySqlDataReader reader = command.ExecuteReader();
            User _user = new User();
            while (reader.Read())
            {
                _user.userId = reader["USERID"].ToString();
                _user.userName = reader["USERNAME"].ToString();
                _user.loginName = reader["LOGINNAME"].ToString();
                _user.password = reader["PASSWORD"].ToString();
                _user.isAdmin = reader["ISADMIN"].ToString() == "0" ? false : true;
                _user.phoneNumber = reader["PHONENUMBER"].ToString();
                _user.dateOfBirth = DateOnly.FromDateTime(DateTime.Parse(reader["DATEOFBIRTH"].ToString()));
                _user.countryId = reader["COUNTRY_NAME"].ToString();
                _user.educationId = reader["EDUCATION_NAME"].ToString();
                _user.email = reader["EMAIL"].ToString();
                _user.facebook = reader["FACEBOOK"].ToString();
                _user.twitter = reader["TWITTER"].ToString();
                _user.linkedIn = reader["LINKEDIN"].ToString();
                _user.departmentId = reader["DEPARTMENT_NAME"].ToString();
                _user.joinDate = DateOnly.FromDateTime(DateTime.Parse(reader["JOIN_DATE"].ToString()));
                _user.roleId = reader["ROLE_NAME"].ToString();
                _user.payrollId = reader["SALARY"].ToString();
                _user.avatar = reader["AVATAR"].ToString();
                _user.gender = reader["GENDER"].ToString() == "0" ? false : true;
            }
            connection.Close();
            return _user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
