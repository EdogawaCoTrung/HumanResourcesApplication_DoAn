using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class AddInsuranceRepository : RepositoryBase, IAddInsurance
    {
        public void AddInsurance(string UserId, string InsuranceId, string StartDate, string EndDate)
        {
            if (connection.State.ToString() == "Closed")
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM INSURANCE_DETAIL WHERE USERID = @UserId AND INSURANCE_ID = @insuranceId";
            command.Parameters.Add("@userId", MySqlDbType.VarString).Value = UserId;
            command.Parameters.Add("@insuranceId", MySqlDbType.VarString).Value = InsuranceId;
            command.ExecuteReader();
            connection.Close();
            connection.Open();
            MySqlCommand command1 = new MySqlCommand();
            command1.Connection = connection;
            command1.CommandText = "INSERT INTO INSURANCE_DETAIL VALUES(@userId,@insuranceId,@startDate,@endDate)";
            command1.Parameters.Add("@userId", MySqlDbType.VarString).Value = UserId;
            command1.Parameters.Add("@insuranceId", MySqlDbType.VarString).Value = InsuranceId;
            command1.Parameters.Add("@startDate",MySqlDbType.Date).Value = StartDate;
            command1.Parameters.Add("@endDate",MySqlDbType.Date).Value= EndDate;
            command1.ExecuteReader();
            connection.Close();
        }
    }
}
