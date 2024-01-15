using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class ListInsuranceRepository : RepositoryBase, IListInsurance
    {
        public List<Insurance> ListInsurance()
        {
            List<Insurance> insurances = new List<Insurance>(); 
            if(connection.State.ToString()=="Closed")
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM INSURANCE";
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Insurance insurance = new Insurance();
                insurance.insuranceId = reader["INSURANCE_ID"].ToString();
                insurance.insuranceType = reader["INSURANCE_TYPE"].ToString();
                insurances.Add(insurance);
            }
            connection.Close();
            return insurances;
        }
    }
}
