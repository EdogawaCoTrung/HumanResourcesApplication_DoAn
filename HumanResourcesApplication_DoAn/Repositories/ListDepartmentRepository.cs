using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    class ListDepartmentRepository:RepositoryBase,IListDepartmentRepository
    {
        public List<Department> ListDepartment() 
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            List<Department> _departments = new List<Department>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM DEPARTMENT LEFT JOIN USERS ON DEPARTMENT.HEAD=USERS.USERID";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Department _department = new Department();
                _department.departmentId = reader["DEPARTMENT_ID"].ToString();
                _department.departmentName = reader["DEPARTMENT_NAME"].ToString();
                _department.head = reader["USERNAME"].ToString()==""?"NULL": reader["USERNAME"].ToString();
                _department.totalEmployees = int.Parse(reader["TOTAL_EMPLOYEES"].ToString());
                _departments.Add(_department);
            }
            connection.Close();
            return _departments;
        }
    }
}
