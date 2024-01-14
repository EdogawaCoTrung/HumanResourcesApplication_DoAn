using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class DeleteProjectRepository : RepositoryBase, IDeleteProjectRepository
    {
        public void Delete(string projectId)
        {
            if (connection.State.ToString() == "Closed")
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM PROJECT WHERE PROJECT_ID = @projectId";
            command.Parameters.Add("@projectId", MySqlDbType.VarString).Value = projectId;
            command.ExecuteReader();
            connection.Close();
        }
    }
}
