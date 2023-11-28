using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HumanResourcesApplication_DoAn.Views.Admin.PayrollView;

namespace HumanResourcesApplication_DoAn.Repositories.DepartmentRepo
{
    class ChangeRepository:RepositoryBase,IChangeDepartmentRepository
    {
    public void ChangeDepartment( string? departmentID,string? departmentName, string? head, int? totalEmployees)
        {
            if(connection.State.ToString()=="Closed")
            {
                connection.Open();
            }
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = connection;
            Command.CommandText = "UPDATE DEPARTMENT SET DEPARTMENT_NAME= @departmentName, HEAD=@head, TOTAL_EMPLOYEES=@totalEmployees WHERE DEPARTMENT_ID=@departmentId";
            Command.Parameters.Add("@departmentID", MySqlDbType.VarString).Value = departmentID;
            Command.Parameters.Add("@departmentName", MySqlDbType.VarString).Value = departmentName;
            Command.Parameters.Add("@head", MySqlDbType.VarString).Value = head;
            Command.Parameters.Add("@totalEmployees", MySqlDbType.VarString).Value = totalEmployees;
            MySqlDataReader reader = Command.ExecuteReader();
            connection.Close();
        }
    }
}
