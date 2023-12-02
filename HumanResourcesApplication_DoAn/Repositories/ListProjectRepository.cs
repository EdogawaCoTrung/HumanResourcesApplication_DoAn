using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.ViewModel.Admin;
using MySql.Data.MySqlClient;

namespace HumanResourcesApplication_DoAn.Repositories
{
    class ListProjectRepository:RepositoryBase,IListProjectRepository
    {
        public List<Project> ListProject()
        {
            if (connection.State.ToString() == "Closed")
            {
                connection.Open();
            }
            List<Project> _listPoject = new List<Project>();

            MySqlCommand Command = new MySqlCommand();
            Command.Connection = connection;
            Command.CommandText = "SELECT * FROM PROJECT JOIN USERS ON PM = USERS.USERID JOIN DEPARTMENT ON PROJECT.DEPARTMENT_ID=DEPARTMENT.DEPARTMENT_ID";
            MySqlDataReader reader = Command.ExecuteReader(); 
            while(reader.Read())
            {
                Project _project = new Project();
                _project.projectId = reader["PROJECT_ID"].ToString();
                _project.projectName = reader["PROJECT_NAME"].ToString();
                _project.startDate = DateOnly.FromDateTime(DateTime.Parse(reader["START_DATE"].ToString()));
                _project.endDate = reader["END_DATE"].ToString()==""? DateOnly.FromDateTime(DateTime.Parse("2023 - 12 - 25")): DateOnly.FromDateTime(DateTime.Parse(reader["END_DATE"].ToString()));   
                _project.projectManager.userName = reader["USERNAME"].ToString();
                _project.department.departmentName = reader["DEPARTMENT_NAME"].ToString();
                _project.description = reader["DESCRIPTION"].ToString();
                _project.numOfMember = reader["NUM_MEMBERS"].ToString();
                _project.revenue = reader["REVENUE"].ToString() ;
                _listPoject.Add(_project);
                 
            }
            connection.Close();
            return _listPoject;
           
        }
    }
}
