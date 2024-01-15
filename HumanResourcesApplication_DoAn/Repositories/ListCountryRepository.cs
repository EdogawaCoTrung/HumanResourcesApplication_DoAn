using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class ListCountryRepository : RepositoryBase, IListCountry
    {
        public List<Country> ListCountry()
        {
            List<Country> list = new List<Country>();
            if( connection.State.ToString()=="Closed")
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand();  
            command.Connection = connection;
            command.CommandText = "SELECT * FROM COUNTRY";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Country country = new Country();
                country.countryId = reader["COUNTRY_ID"].ToString();
                country.countryName = reader["COUNTRY_NAME"].ToString();
                list.Add(country);
            }
            connection.Close();
            return list;
        }
    }
}
