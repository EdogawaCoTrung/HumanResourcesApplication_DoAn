using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class ChangeBaseSalaryRepository : RepositoryBase, IChangeBaseSalaryRepository
    {
        public void ChangeBaseSalary(string payrollId,string roleId, double salary)
        {
            if(connection.State.ToString()=="Closed")
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE PAYROLL SET ROLE_ID = @roleId,SALARY = @salary WHERE PAYROLL_ID = @payrollId ";
            command.Parameters.Add("@payrollId",MySqlDbType.VarString).Value = payrollId;
            command.Parameters.Add("@roleId",MySqlDbType.VarString).Value = roleId;
            command.Parameters.Add("@salary",MySqlDbType.Double).Value = salary;
            command.ExecuteReader();
            connection.Close();
        }
    }
}
