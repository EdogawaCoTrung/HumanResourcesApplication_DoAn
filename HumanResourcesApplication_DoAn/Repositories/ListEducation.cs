using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class ListEducation : RepositoryBase, IListEducation
    {
        public List<Education> ListEducations()
        {
            List<Education> list = new List<Education>();
            if(connection.State.ToString()=="Closed")
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM EDUCATION";
            MySqlDataReader reader = command.ExecuteReader();   
            while(reader.Read()) 
            {
                Education education = new Education();
                education.educationId = reader["EDUCATION_ID"].ToString();
                education.educationName = reader["EDUCATION_NAME"].ToString();
                list.Add(education);
            }
            connection.Close();
            return list;
        }
    }
}
