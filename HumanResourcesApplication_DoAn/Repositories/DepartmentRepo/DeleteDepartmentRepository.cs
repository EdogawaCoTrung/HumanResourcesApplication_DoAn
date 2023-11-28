using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using static HumanResourcesApplication_DoAn.Views.Admin.PayrollView;

namespace HumanResourcesApplication_DoAn.Repositories.DepartmentRepo
{
    class DeleteDepartmentRepository:RepositoryBase,IDeleteDepartmentRepository
    {
        public void DeleteDepartment(string? _departmentID, string? _departmentName, string? _head, int? _totalEmployees)
        {
            if(connection.State.ToString()=="Closed")
            {
                connection.Open();
            }
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = connection;
            Command.CommandText = "DELETE FROM DEPARTMENT WHERE @_departmentID=DEPARTMENT_ID";
            Command.Parameters.Add("@_departmentID", MySqlDbType.VarString).Value = _departmentID;
            MySqlDataReader reader = Command.ExecuteReader();
            connection.Close();
        }
    }
}
