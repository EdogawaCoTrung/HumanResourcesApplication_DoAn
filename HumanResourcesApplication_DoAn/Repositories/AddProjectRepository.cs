using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class AddProjectRepository : RepositoryBase,IAddProjectRepository
    {
        public void AddProject(string projectName, string startDate, string endDate, string projectManager, string departmentName, string numberOfMember, string description, string revenue, string type)
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(PROJECT_ID) AS ID FROM PROJECT";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = int.Parse(reader["ID"].ToString()) + 1;
            string project_Id = "0" + count.ToString();
            connection.Close();

            connection.Open();
            command.Connection = connection;
            command.CommandText = "INSERT INTO PROJECT VALUES(@project_id,@project_name,@startDate,@endDate,@projectManager,@departmentName,@numberOfMember,@description,@revenue, @type)";
            command.Parameters.Add("@project_id",MySqlDbType.VarString).Value = project_Id;
            command.Parameters.Add("@project_name", MySqlDbType.VarString).Value = projectName;
            command.Parameters.Add("@startDate",MySqlDbType.Date).Value = startDate;
            command.Parameters.Add("@endDate", MySqlDbType.Date).Value = endDate;
            command.Parameters.Add("@projectManager", MySqlDbType.VarString).Value = projectManager;
            command.Parameters.Add("@departmentName", MySqlDbType.VarString).Value = departmentName;
            command.Parameters.Add("@numberOfMember", MySqlDbType.Int32).Value =Int32.Parse(numberOfMember);
            command.Parameters.Add("@description", MySqlDbType.VarString).Value = description;
            command.Parameters.Add("@revenue", MySqlDbType.Int32).Value = Int32.Parse(revenue);
            command.Parameters.Add("@type", MySqlDbType.VarString).Value = type;
            command.ExecuteReader();
            connection.Close();
        }
    }
}
