using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class AttendanceRepository : RepositoryBase, IAttendanceRepository
    {
        public List<Attendance?> GetAttendanceByUserId(string? userId)
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM ATTENDANCE WHERE @userId = USERID";
            command.Parameters.Add("@userId", MySqlDbType.VarString).Value = userId;
            MySqlDataReader reader = command.ExecuteReader();
            List<Attendance?> attendances = new List<Attendance?>();
            while (reader.Read())
            {
                Attendance _attendance = new Attendance();
                _attendance.userId = reader["ATTENDANCE_ID"].ToString();
                _attendance.userId = reader["USERID"].ToString();
                _attendance.date = DateOnly.FromDateTime(DateTime.Parse(reader["DATE_ATTENDANCE"].ToString()));
                _attendance.inTime = TimeSpan.Parse(reader["INTIME"].ToString() == "" ? "00:00:00" : reader["INTIME"].ToString());
                _attendance.outTime = TimeSpan.Parse(reader["OUTTIME"].ToString() == "" ? "00:00:00" : reader["OUTTIME"].ToString());
                _attendance.hours = _attendance.outTime - _attendance.inTime;
                _attendance.status = reader["STATUS_ATTENDANCE"].ToString() == "0" ? "Absent" : "Present";
                attendances.Add(_attendance);
            }
            connection.Close();
            return attendances;
        }
    }
}
