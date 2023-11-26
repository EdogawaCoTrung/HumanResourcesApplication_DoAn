using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class SendLeaveRequestRepository : RepositoryBase, ISendLeaveRequestRepository
    {
        public void SendLeaveRequest(string? userId, string? startDate, string? endDate, string? reason, string? leaveType)
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(LEAVE_ID) AS ID FROM LEAVE_REQUEST";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = int.Parse(reader["ID"].ToString()) + 1;
            string leave_id = "0" + count.ToString();
            connection.Close();

            connection.Open();
            command.Connection = connection;
            command.CommandText = "INSERT INTO LEAVE_REQUEST (LEAVE_ID, USERID, STARTDATE, ENDDATE, REASON, LEAVE_TYPE) VALUES (@leave_id, @userId, @startDate, @endDate, @reason, @leaveType);";
            command.Parameters.Add("@leave_id", MySqlDbType.VarString).Value = leave_id;
            command.Parameters.Add("@userId", MySqlDbType.VarString).Value = userId;
            command.Parameters.Add("@startDate", MySqlDbType.Date).Value = startDate;
            command.Parameters.Add("@endDate", MySqlDbType.Date).Value = endDate;
            command.Parameters.Add("@reason", MySqlDbType.VarString).Value = reason;
            command.Parameters.Add("@leaveType", MySqlDbType.VarString).Value = leaveType;
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
