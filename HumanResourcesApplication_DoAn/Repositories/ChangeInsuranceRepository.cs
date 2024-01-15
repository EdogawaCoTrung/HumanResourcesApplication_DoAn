using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class ChangeInsuranceRepository : RepositoryBase, IChangeInsurance
    {
        public void ChangeInsurance(string InsuranceId, string UserId, string StartDate, string EndDate)
        {
            if (connection.State.ToString() == "Closed")
            {
                connection.Open();
            }
            MySqlCommand command2 = new MySqlCommand();
            command2.Connection = connection;
            command2.CommandText = "UPDATE INSURANCE_DETAIL SET USERID=@UserId, INSURANCE_ID=@InsuranceId, START_DATE= @startDate, END_DATE=@endDate WHERE USERID=@userId AND INSURANCE_ID=@insuranceId";
            command2.Parameters.Add("@userId", MySqlDbType.VarString).Value = UserId;
            command2.Parameters.Add("@insuranceId", MySqlDbType.VarString).Value = InsuranceId;
            command2.Parameters.Add("@startDate", MySqlDbType.Date).Value = StartDate;
            command2.Parameters.Add("@endDate", MySqlDbType.Date).Value = EndDate;
            command2.ExecuteReader();
            connection.Close();

        }
    }
}
