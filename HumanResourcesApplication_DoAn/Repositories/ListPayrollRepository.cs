using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class ListPayrollRepository : RepositoryBase, IListPayrollRepository
    {
        public List<Payroll>? ListPayrolls()
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            List<Payroll> _payrolls = new List<Payroll>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT USERS.USERNAME, USERS.EMAIL, USERS.AVATAR, ROLE.ROLE_NAME, PAYROLL.SALARY, DEPARTMENT.DEPARTMENT_NAME FROM USERS JOIN PAYROLL ON USERS.PAYROLL_ID = PAYROLL.PAYROLL_ID JOIN ROLE ON USERS.ROLE_ID = ROLE.ROLE_ID JOIN DEPARTMENT ON USERS.DEPARTMENT_ID = DEPARTMENT.DEPARTMENT_ID";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Payroll _payroll = new Payroll();
                _payroll.user.userName = reader["USERNAME"].ToString();
                _payroll.user.email = reader["EMAIL"].ToString();
                _payroll.user.avatar = reader["AVATAR"].ToString();
                _payroll.role.roleName = reader["ROLE_NAME"].ToString();
                _payroll.salary = int.Parse(reader["SALARY"].ToString());
                _payroll.department.departmentName = reader["DEPARTMENT_NAME"].ToString(); 
                _payrolls.Add(_payroll);
            }
            connection.Close();
            return _payrolls;
        }
    }
}
