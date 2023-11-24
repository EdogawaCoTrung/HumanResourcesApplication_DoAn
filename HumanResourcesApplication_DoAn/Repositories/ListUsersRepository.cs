using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class ListUsersRepository : RepositoryBase, IListUsersRepository
    {
        public List<User> ListUsers()
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            List<User> _users = new List<User>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM USERS JOIN ROLE ON USERS.ROLE_ID = ROLE.ROLE_ID";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User _user = new User();
                _user.userId = reader["USERID"].ToString();
                _user.userName = reader["USERNAME"].ToString();
                _user.loginName = reader["LOGINNAME"].ToString();
                _user.password = reader["PASSWORD"].ToString();
                _user.isAdmin = reader["ISADMIN"].ToString() == "0" ? false : true;
                _user.phoneNumber = reader["PHONENUMBER"].ToString();
                _user.dateOfBirth = DateTime.Parse(reader["DATEOFBIRTH"].ToString());
                _user.countryId = reader["COUNTRY_ID"].ToString();
                _user.educationId = reader["EDUCATION_ID"].ToString();
                _user.email = reader["EMAIL"].ToString();
                _user.facebook = reader["FACEBOOK"].ToString();
                _user.twitter = reader["TWITTER"].ToString();
                _user.linkedIn = reader["LINKEDIN"].ToString();
                _user.departmentId = reader["DEPARTMENT_ID"].ToString();
                _user.joinDate = DateTime.Parse(reader["JOIN_DATE"].ToString());
                _user.roleId = reader["ROLE_NAME"].ToString();
                _user.payrollId = reader["PAYROLL_ID"].ToString();
                _user.avatar = reader["AVATAR"].ToString();
                _user.gender = reader["GENDER"].ToString() == "0" ? false : true;
                _users.Add(_user);
            }
            connection.Close();
            return _users;
        }
    }
}
