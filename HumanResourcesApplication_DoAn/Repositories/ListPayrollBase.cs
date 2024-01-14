using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class ListPayrollBase : RepositoryBase, IListPayrollBase
    {
        public List<PayrollBase> ListPayrollBaseFunc()
        {
            List<PayrollBase> listPayrollBase = new List<PayrollBase>();   
            if (connection.State.ToString() == "Closed")
                {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT PAYROLL.PAYROLL_ID, ROLE.ROLE_NAME, SALARY FROM PAYROLL JOIN ROLE ON PAYROLL.ROLE_ID = ROLE.ROLE_ID";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                PayrollBase payroll = new PayrollBase();
                payroll.payrollId = reader["PAYROLL_ID"].ToString();
                payroll.role.roleName = reader["ROLE_NAME"].ToString();
                payroll.salary = Double.Parse(reader["SALARY"].ToString()) ;
                listPayrollBase.Add(payroll);
            }
            connection.Close();
            return listPayrollBase;
        }
    }
}
