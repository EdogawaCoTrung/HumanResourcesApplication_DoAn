using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    class GetPayrollByIdRepository:RepositoryBase,IGetPayrollByIdRepository
    {
        
        public List<EmployeePayroll> GetPayrollById(string userId)
        {
            if(connection.State.ToString()=="Closed")
            {
                connection.Open();
            }
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = connection;
            Command.CommandText = "SELECT * FROM PAYROLL_HISTORY JOIN PAYROLL ON PAYROLL.PAYROLL_ID = PAYROLL_HISTORY.PAYROLL_ID JOIN USERS ON PAYROLL_HISTORY.USERID = USERS.USERID WHERE USERS.USERID = @userId";
            Command.Parameters.Add("@userId",MySqlDbType.VarString).Value= userId;
            MySqlDataReader reader = Command.ExecuteReader();
            List<EmployeePayroll> employeePayroll = new List<EmployeePayroll>();
            while (reader.Read())
            {
                EmployeePayroll _employeePayroll = new EmployeePayroll();  
                _employeePayroll.Payroll.salary = int.Parse(reader["SALARY"].ToString()) ;
                _employeePayroll.PayrollHistory.StartDate = DateOnly.FromDateTime(DateTime.Parse(reader["START_DATE"].ToString()));
                _employeePayroll.PayrollHistory.EndDate = DateOnly.FromDateTime(DateTime.Parse(reader["END_DATE"].ToString() == "" ? "31/12/2024" : reader["END_DATE"].ToString()));
                _employeePayroll.User.userName = reader["USERNAME"].ToString();
                _employeePayroll.User.userId = reader["USERID"].ToString();
                employeePayroll.Add(_employeePayroll);
            }
            connection.Close();
            return employeePayroll;

        }
    }
}
