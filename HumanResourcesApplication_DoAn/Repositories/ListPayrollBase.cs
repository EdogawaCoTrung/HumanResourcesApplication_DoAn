using HumanResourcesApplication_DoAn.Model;
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
            return new List<PayrollBase>();
        }
        //{
        //    if (connection.State.ToString() == "Closed")
        //    {
        //        connection.Open();
        //    }
        //    MySqlCommand command = new MySqlCommand();
        //    command.Connection = connection;
        //    command.CommandText = "SELECT PAYROLL.PAYROLL_ID, ROLE.ROLE"
        
    }
}
