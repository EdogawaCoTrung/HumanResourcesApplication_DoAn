using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class AddUserRepository : RepositoryBase, IAddUserRepository
    {
        public void AddUser(string? userName, string? loginName, string? password, string? isAdmin, string? phoneNumber, string? dateOfBirth, string? country, string? education, string? gender, string? joinDate, string? role, string? payroll, string? facebook, string? twitter, string? linkedIn, string? email, string? avatar, string? departmentId)
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(USERID) AS ID FROM USERS";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = int.Parse(reader["ID"].ToString()) + 1;
            string userId = "0" + count.ToString();
            connection.Close();

            connection.Open();
            command.Connection = connection;
            command.CommandText = "INSERT INTO USERS (USERID, USERNAME, LOGINNAME, PASSWORD, ISADMIN, PHONENUMBER, DATEOFBIRTH, GENDER, COUNTRY_ID, EDUCATION_ID, EMAIL, AVATAR, FACEBOOK, TWITTER, LINKEDIN, DEPARTMENT_ID, JOIN_DATE, ROLE_ID, PAYROLL_ID) VALUES (@userId, @userName, @loginName, @password, @isAdmin, @phoneNumber, @dateOfBirth, @gender, @country, @education, @email, @avatar, @facebook, @twitter, @linkedIn, @department, @joinDate, @role, @payroll);";
            command.Parameters.Add("@userId", MySqlDbType.VarString).Value = userId;
            command.Parameters.Add("@userName", MySqlDbType.VarString).Value = userName;
            command.Parameters.Add("@loginName", MySqlDbType.VarString).Value = loginName;
            command.Parameters.Add("@password", MySqlDbType.VarString).Value = password;
            command.Parameters.Add("@isAdmin", MySqlDbType.Bit).Value = isAdmin;
            command.Parameters.Add("@phoneNumber", MySqlDbType.VarString).Value = phoneNumber;           
            command.Parameters.Add("@dateOfBirth", MySqlDbType.Date).Value = dateOfBirth;
            command.Parameters.Add("@gender", MySqlDbType.Bit).Value = gender;
            command.Parameters.Add("@country", MySqlDbType.VarString).Value = country;
            command.Parameters.Add("@education", MySqlDbType.VarString).Value = education;
            command.Parameters.Add("@email", MySqlDbType.VarString).Value = email;
            command.Parameters.Add("@avatar", MySqlDbType.VarString).Value = avatar;            
            command.Parameters.Add("@facebook", MySqlDbType.VarString).Value = facebook;
            command.Parameters.Add("@twitter", MySqlDbType.VarString).Value = twitter;
            command.Parameters.Add("@linkedIn", MySqlDbType.VarString).Value = linkedIn;
            command.Parameters.Add("@department", MySqlDbType.VarString).Value = departmentId;
            command.Parameters.Add("@joinDate", MySqlDbType.Date).Value = joinDate;
            command.Parameters.Add("@role", MySqlDbType.VarString).Value = role;
            command.Parameters.Add("@payroll", MySqlDbType.VarString).Value = payroll;
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}

