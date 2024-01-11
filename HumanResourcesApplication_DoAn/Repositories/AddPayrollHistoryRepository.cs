using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class AddPayrollHistoryRepository : RepositoryBase, IAddPayrollHistoryRepository
    {
        public void AddPayrollHistory(string? _userId, string? _payrollId, DateOnly? _startDate, DateOnly? _endDate)
        {
            if(connection.State.ToString()=="Closed")
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO PAYROLL_HISTORY(USERID,PAYROLL_ID,START_DATE,END_DATE) VALUES (@userid, @payroll_id, @start_date, @end_date)";
            command.Parameters.Add("@userid", MySqlDbType.VarString).Value = _userId;
            command.Parameters.Add("@payroll_id", MySqlDbType.VarString).Value = _payrollId;
            command.Parameters.Add("@start_date", MySqlDbType.Date).Value = _startDate;
            command.Parameters.Add("@end_date", MySqlDbType.Date).Value = _endDate;
            MySqlDataReader reader = command.ExecuteReader();
            connection.Close();

        }
    }
}
