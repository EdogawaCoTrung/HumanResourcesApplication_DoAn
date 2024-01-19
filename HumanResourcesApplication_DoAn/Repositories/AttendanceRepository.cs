using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            command.CommandText = "SELECT * FROM ATTENDANCE JOIN USERS ON USERS.USERID = ATTENDANCE.USERID WHERE @userId = ATTENDANCE.USERID";
            command.Parameters.Add("@userId", MySqlDbType.VarString).Value = userId;
            MySqlDataReader reader = command.ExecuteReader();
            List<Attendance?> attendances = new List<Attendance?>();
            while (reader.Read())
            {
                Attendance _attendance = new Attendance();
                _attendance.userId.userId = reader["USERID"].ToString();
                _attendance.date = DateOnly.FromDateTime(DateTime.Parse(reader["DATE_ATTENDANCE"].ToString()));
                _attendance.inTime = TimeSpan.Parse(reader["INTIME"].ToString() == "" ? "00:00:00" : reader["INTIME"].ToString());
                _attendance.outTime = TimeSpan.Parse(reader["OUTTIME"].ToString() == "" ? "00:00:00" : reader["OUTTIME"].ToString());
                _attendance.hours = _attendance.outTime - TimeSpan.Parse("17:00:00");
                if (_attendance.hours < TimeSpan.Parse("00:00:00"))
                {
                    _attendance.hours = TimeSpan.Parse("00:00:00");
                }
                _attendance.status = reader["STATUS_ATTENDANCE"].ToString() == "0" ? "Absent" : "Present";
                attendances.Add(_attendance);
            }
            connection.Close();
            return attendances;
        }

        public void AddAttendance(string? userId)
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM ATTENDANCE WHERE USERID = @userId AND DATE_ATTENDANCE = @date";
            string date = DateOnly.FromDateTime(DateTime.Now).ToString();
            date = date.Substring(6, 4) + "-" + date.Substring(3, 2) + "-" + date.Substring(0, 2);
            string inTime = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            command.Parameters.Add("@userId", MySqlDbType.VarString).Value = userId;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            MySqlDataReader reader = command.ExecuteReader();
            string attendanceId = "";
            string outTime = "";
            if (reader.Read())
            {
                attendanceId = reader["ATTENDANCE_ID"].ToString();
                outTime = reader["OUTTIME"].ToString();
            }
            command.Parameters.Clear();
            command.CommandText = "";
            reader.Close();
            if (attendanceId == "")
            {
                command.CommandText = "SELECT COUNT(ATTENDANCE_ID) FROM ATTENDANCE";
                reader = command.ExecuteReader();
                reader.Read();
                attendanceId = "0" + (int.Parse(reader["COUNT(ATTENDANCE_ID)"].ToString()) + 50).ToString();
                command.Parameters.Clear();
                command.CommandText = "";
                reader.Close();

                command.CommandText = "INSERT INTO ATTENDANCE(ATTENDANCE_ID, USERID, DATE_ATTENDANCE, INTIME, OUTTIME, STATUS_ATTENDANCE) VALUES (@attendanceId, @userId, @date, @inTime, NULL, b'1')";
                command.Parameters.AddWithValue("@attendanceId", attendanceId);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@inTime", inTime);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                MessageBox.Show("Bạn đã điểm danh vào làm thành công!");
            }
            else if (outTime == "")
            {
                outTime = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                command.CommandText = "UPDATE ATTENDANCE SET OUTTIME = @outTime WHERE USERID = @userId AND DATE_ATTENDANCE = @date";
                command.Parameters.AddWithValue("@outTime", outTime);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@date", date);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                MessageBox.Show("Bạn đã điểm danh ra về thành công!");
            }
            else
            {
                MessageBox.Show("Bạn đã điểm danh ngày hôm nay rồi!");
            }
            connection.Close();
        }

    }
}
