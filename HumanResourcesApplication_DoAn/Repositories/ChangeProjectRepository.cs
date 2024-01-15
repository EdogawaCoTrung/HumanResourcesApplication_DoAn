using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Views.Admin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class ChangeProjectRepository : RepositoryBase, IChangeProjectRepository
    {
        public void ChangeProject(string projectId, string projectName, string startDate, string endDate, string projectManager, string departmentName, string numberOfMember, string description, string revenue, string type)
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE PROJECT SET PROJECT_NAME=@project_name,START_DATE=@startDate,END_DATE=@endDate,PM=@projectManager,DEPARTMENT_ID=@departmentName,DESCRIPTION=@description,NUM_MEMBERS=@numberOfMember,REVENUE = @revenue, TYPE = @type WHERE PROJECT_ID = @project_id";
            command.Parameters.Add("@project_id", MySqlDbType.VarString).Value = projectId;
            command.Parameters.Add("@project_name", MySqlDbType.VarString).Value = projectName;
            command.Parameters.Add("@startDate", MySqlDbType.Date).Value = startDate;
            command.Parameters.Add("@endDate", MySqlDbType.Date).Value = endDate;
            command.Parameters.Add("@projectManager", MySqlDbType.VarString).Value = projectManager;
            command.Parameters.Add("@departmentName", MySqlDbType.VarString).Value = departmentName;
            command.Parameters.Add("@numberOfMember", MySqlDbType.Int32).Value = Int32.Parse(numberOfMember);
            command.Parameters.Add("@description", MySqlDbType.VarString).Value = description;
            command.Parameters.Add("@revenue", MySqlDbType.Int32).Value = Int32.Parse(revenue);
            command.Parameters.Add("@type", MySqlDbType.VarString).Value = type;
            command.ExecuteReader();
            connection.Close();
        }
    }
}
