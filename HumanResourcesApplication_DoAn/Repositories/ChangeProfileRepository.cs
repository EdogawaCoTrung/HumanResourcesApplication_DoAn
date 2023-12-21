using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class ChangeProfileRepository : RepositoryBase, IChangeProfileRepository
    {
        public void ChangeProfile(string? loginName, string? userName, string? password, string? phoneNumber, string? dateOfBirth, string? gender, string? country, string? education, string? facebook, string? twitter, string? linkedIn, string? email, string? avatar)
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.Parameters.Add("@loginName", MySqlDbType.VarString).Value = loginName;
            if (userName != null && userName != "")
            {
                command.CommandText += "UPDATE USERS SET USERNAME = @userName WHERE LOGINNAME = @loginName;";
                command.Parameters.Add("@userName", MySqlDbType.VarString).Value = userName;
            }
            if (password != null && password != "") {
                command.CommandText += "UPDATE USERS SET PASSWORD = @password WHERE LOGINNAME = @loginName;";
                command.Parameters.Add("@password", MySqlDbType.VarString).Value = password;
            }
            if (phoneNumber != null && phoneNumber != "")
            {
                command.CommandText += "UPDATE USERS SET PHONENUMBER = @phoneNumber WHERE LOGINNAME = @loginName;";
                command.Parameters.Add("@phoneNumber", MySqlDbType.VarString).Value = phoneNumber;
            }
            if (dateOfBirth != null && dateOfBirth != "")
            {
                command.CommandText += "UPDATE USERS SET DATEOFBIRTH = @dateOfBirth WHERE LOGINNAME = @loginName;";
                command.Parameters.Add("@dateOfBirth", MySqlDbType.Date).Value = dateOfBirth;
            }
            if (gender != null && gender != "")
            {
                command.CommandText += "UPDATE USERS SET GENDER = @gender WHERE LOGINNAME = @loginName;";
                command.Parameters.Add("@gender", MySqlDbType.Bit).Value = gender == "Male" ?   "1" :   "0";
            }
            if (country != null && country != "")
            {
                command.CommandText += "UPDATE USERS SET USERS.COUNTRY_ID = COUNTRY.COUNTRY_ID WHERE LOGINNAME = @loginName AND COUNTRY_NAME = @country;";
                command.Parameters.Add("@country", MySqlDbType.VarString).Value = country;
            }
            if (education != null && education != "")
            {
                command.CommandText += "UPDATE USERS SET USERS.EDUCATION_ID = EDUCATION.EDUCATION_ID WHERE LOGINNAME = @loginName AND EDUCATION_NAME = @education;";
                command.Parameters.Add("@education", MySqlDbType.VarString).Value = education;
            }
            if (facebook != null && facebook != "")
            {
                command.CommandText += "UPDATE USERS SET FACEBOOK = @facebook WHERE LOGINNAME = @loginName;";
                command.Parameters.Add("@facebook", MySqlDbType.VarString).Value = facebook;
            }
            if (twitter != null && twitter != "")
            {
                command.CommandText += "UPDATE USERS SET TWITTER = @twitter WHERE LOGINNAME = @loginName;";
                command.Parameters.Add("@twitter", MySqlDbType.VarString).Value = twitter;
            }
            if (linkedIn != null && linkedIn != "")
            {
                command.CommandText += "UPDATE USERS SET LINKEDIN = @linkedIn WHERE LOGINNAME = @loginName;";
                command.Parameters.Add("@linkedIn", MySqlDbType.VarString).Value = linkedIn;
            }
            if (email != null && email != "")
            {
                command.CommandText += "UPDATE USERS SET EMAIL = @email WHERE LOGINNAME = @loginName;";
                command.Parameters.Add("@email", MySqlDbType.VarString).Value = email;
            }
            if (avatar != null & avatar != "")
            {
                command.CommandText += "UPDATE USERS SET AVATAR = @avatar WHERE LOGINNAME = @loginName;";
                command.Parameters.Add("@avatar", MySqlDbType.VarString).Value = avatar;
            }
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            connection.Close();
        }
    }
}
