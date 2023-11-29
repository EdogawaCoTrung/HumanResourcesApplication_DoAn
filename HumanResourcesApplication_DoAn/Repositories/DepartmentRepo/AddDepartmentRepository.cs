using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using static HumanResourcesApplication_DoAn.Views.Admin.PayrollView;
using System.Windows;

namespace HumanResourcesApplication_DoAn.Repositories.DepartmentRepo
{
    class AddDepartmentRepository: RepositoryBase,IAddDepertmentRepository
    {
        public void AddDepartment(string? _departmentName, string? _head, int? _totalEmployees)
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(DEPARTMENT_ID) AS ID FROM DEPARTMENT";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = int.Parse(reader["ID"].ToString()) + 1;
            string _departmentID = "0" + count.ToString();
            connection.Close();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "INSERT INTO DEPARTMENT(DEPARTMENT_ID, DEPARTMENT_NAME,HEAD,TOTAL_EMPLOYEES) VALUES (@_departmentID,@_departmentName,@_head,@_totalEmployees)";
            command.Parameters.Add("@_departmentID", MySqlDbType.VarString).Value = _departmentID;
            command.Parameters.Add("@_departmentName", MySqlDbType.VarString).Value = _departmentName;
            command.Parameters.Add("@_head", MySqlDbType.VarString).Value = _head;
            command.Parameters.Add("@_totalEmployees", MySqlDbType.Int32).Value = _totalEmployees;
            reader = command.ExecuteReader();

            connection.Close();
        }
    }
}
