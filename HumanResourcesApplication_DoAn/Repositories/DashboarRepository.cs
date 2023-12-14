using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class DashboarRepository :RepositoryBase
    {
        private static DashboarRepository instance; 
        public static DashboarRepository Instance
        {
            get { 
                if(instance == null)
                    instance = new DashboarRepository();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        public string QueryOrganicPJInYear(string currentYear)
        {
            string s = "0", type = "Organic";
            if (connection.State.ToString() == "Closed")
            {
                connection.Open();
            }
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = connection;
            Command.CommandText = "SELECT SUM(REVENUE) AS TONG FROM PROJECT WHERE TYPE =@type AND YEAR(END_DATE)=@currentYear";
            Command.Parameters.Add("@type",MySqlDbType.VarString).Value = type;
            Command.Parameters.Add("@currentYear", MySqlDbType.VarString).Value = currentYear;
            MySqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                s = reader["TONG"].ToString();
            }
            connection.Close();
            return s;
        }
        public int QueryTotalDepartmentInYear(string currentYear)
        {
            int s = 0;
            if (connection.State.ToString() == "Closed")
            {
                connection.Open();
            }
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = connection;
            Command.CommandText = "SELECT COUNT(DEPARTMENT_ID) AS DEM FROM DEPARTMENT";
   
            MySqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                s = int.Parse(reader["DEM"].ToString());
            }
            connection.Close();
            return s;
        }
        public int QueryTotalEmployeeInYear(string currentYear)
        {
            
                int s = 0;
                if (connection.State.ToString() == "Closed")
                {
                    connection.Open();
                }
                MySqlCommand Command = new MySqlCommand();
                Command.Connection = connection;
                Command.CommandText = "SELECT COUNT(USERID) AS DEM FROM USERS";

                MySqlDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    s = int.Parse(reader["DEM"].ToString());
                }
                connection.Close();
                return s;
        }
        public string QueryDirectPJRevenueInYear(string currentYear)
        {
            string s = "0", type = "Diret";
            if (connection.State.ToString() == "Closed")
            {
                connection.Open();
            }
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = connection;
            Command.CommandText = "SELECT SUM(REVENUE) AS TONG FROM PROJECT WHERE TYPE=@type AND YEAR(END_DATE)=@currentYear";
            Command.Parameters.Add("@type", MySqlDbType.VarString).Value = type;
            Command.Parameters.Add("@currentYear", MySqlDbType.VarString).Value = currentYear;
            MySqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                s = reader["TONG"].ToString();
            }
            connection.Close();
            return s;
        }
        public string QueryReferralPJRevenueInYear(string currentYear)
        {
            string s = "0", type = "Referral";
            if (connection.State.ToString() == "Closed")
            {
                connection.Open();
            }
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = connection;
            Command.CommandText = "SELECT SUM(REVENUE) AS TONG FROM PROJECT WHERE TYPE =@type AND YEAR(END_DATE)=@currentYear";
            Command.Parameters.Add("@type", MySqlDbType.VarString).Value = type;
            Command.Parameters.Add("@currentYear", MySqlDbType.VarString).Value = currentYear;
            MySqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                s = reader["TONG"].ToString();
            }
            connection.Close();
            return s;
        }
    }
}
