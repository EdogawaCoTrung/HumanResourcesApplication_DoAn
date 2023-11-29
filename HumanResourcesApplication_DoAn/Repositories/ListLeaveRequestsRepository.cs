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
    public class ListLeaveRequestsRepository : RepositoryBase, IListLeaveRequestsRepository
    {
        public List<LeaveRequest> ListLeaveRequests()
        {
            if(connection.State.ToString() == "Closed")
                connection.Open();
            List<LeaveRequest> _leaveRequests = new List<LeaveRequest>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM LEAVE_REQUEST JOIN USERS ON LEAVE_REQUEST.USERID = USERS.USERID";
            MySqlDataReader reader = command.ExecuteReader();
            BindingImage bindingImage = new BindingImage();
            while (reader.Read())
            {
                LeaveRequest _leaveRequest = new LeaveRequest();
                _leaveRequest.leaveId = reader["LEAVE_ID"].ToString();
                _leaveRequest.userId = reader["USERID"].ToString();
                _leaveRequest.startDate = DateOnly.FromDateTime(DateTime.Parse(reader["STARTDATE"].ToString()));
                _leaveRequest.endDate = DateOnly.FromDateTime(DateTime.Parse(reader["ENDDATE"].ToString()));
                _leaveRequest.reason = reader["REASON"].ToString();
                _leaveRequest.leaveType = reader["LEAVE_TYPE"].ToString();
                _leaveRequest.User.userName = reader["USERNAME"].ToString();
                _leaveRequest.User.avatar = reader["AVATAR"].ToString();
                _leaveRequest.User.avatar = bindingImage.ConvertPath(_leaveRequest.User.avatar);
                _leaveRequests.Add(_leaveRequest);
            }
            connection.Close();
            return _leaveRequests;
        }
    }
}
