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
    public class ListAttendanceRepository : RepositoryBase, IListAttendanceRepository
    {
        public List<Attendance> ListAttendance()
        {
            if (connection.State.ToString() == "Closed")
                connection.Open();
            List<Attendance> _listAttendance = new List<Attendance>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM ATTENDANCE JOIN USERS ON USERS.USERID = ATTENDANCE.USERID";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Attendance _attendance = new Attendance();
                _attendance.userId = reader["USERNAME"].ToString();
                _attendance.date = DateOnly.FromDateTime(DateTime.Parse(reader["DATE_ATTENDANCE"].ToString()));
                _attendance.inTime = TimeSpan.Parse(reader["INTIME"].ToString() == "" ? "00:00:00" : reader["INTIME"].ToString());
                _attendance.outTime = TimeSpan.Parse(reader["OUTTIME"].ToString() == "" ? "00:00:00" : reader["OUTTIME"].ToString());
                _attendance.hours = _attendance.outTime - TimeSpan.Parse("17:00:00");
                if (_attendance.hours < TimeSpan.Parse("00:00:00"))
                {
                    _attendance.hours = TimeSpan.Parse("00:00:00");
                }
                _attendance.status = reader["STATUS_ATTENDANCE"].ToString() == "0" ? "Absent" : "Present";
                _listAttendance.Add(_attendance);
            }
            connection.Close();

            ////

            //if (connection.State.ToString() == "Closed")
            //    connection.Open();
            //command.Connection = connection;
            //int mod = 365;
            //string _date = "2023-12-";
            //string date = "10";
            //for (int i = 366; i <= 563; i++)
            //{
            //    date = date[date.Length - 2].ToString() + date[date.Length - 1].ToString();
            //    if (i % mod == 10)
            //    {
            //        mod = i - 1;
            //        date = _date + (int.Parse(date) + 1).ToString();

            //    }
            //    else date = _date + date;
            //    string id = "0" + i.ToString();
            //    string userId = "0" + (i % mod).ToString();
            //    command.Parameters.AddWithValue("@id", id);
            //    command.Parameters.AddWithValue("@userId", userId);
            //    command.Parameters.AddWithValue("@date", date);
            //    command.CommandText = "INSERT INTO `ATTENDANCE` (`ATTENDANCE_ID`, `USERID`, `DATE_ATTENDANCE`, `INTIME`, `OUTTIME`, `STATUS_ATTENDANCE`) VALUES (@id, @userId, @date, '07:00:00', '17:00:00', b'1')";
            //    command.ExecuteNonQuery();
            //    command.CommandText = "";
            //    command.Parameters.Clear();
            //}
            //connection.Close();
            return (_listAttendance);
        }
    }
}
