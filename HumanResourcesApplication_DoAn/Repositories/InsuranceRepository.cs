using HumanResourcesApplication_DoAn.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public class InsuranceRepository : RepositoryBase, IInsuranceRepository
    {
        void IInsuranceRepository.Add(Insurance user)
        {
            throw new NotImplementedException();
        }

        void IInsuranceRepository.Edit(Insurance user)
        {
            throw new NotImplementedException();
        }

        List<InsuranceForView> IInsuranceRepository.GetByAll()
        {
            if(connection.State.ToString()=="Closed")
            {
                connection.Open(); 
            }
            List<InsuranceForView> _listInsuranceForView = new List<InsuranceForView>();
            MySqlCommand Command = new MySqlCommand();
            Command.Connection = connection;
            Command.CommandText = "SELECT * FROM INSURANCE JOIN INSURANCE_DETAIL ON INSURANCE.INSURANCE_ID = INSURANCE_DETAIL.INSURANCE_ID JOIN USERS ON INSURANCE_DETAIL.USERID=USERS.USERID";
            MySqlDataReader reader = Command.ExecuteReader(); 
            while(reader.Read())
            {
                InsuranceForView element= new InsuranceForView();
                element._insuranceId = reader["INSURANCE_ID"].ToString();
                element._insuranceName = reader["INSURANCE_TYPE"].ToString();
                element._userName = reader["USERNAME"].ToString();
                if (reader["START_DATE"].ToString() != "")
                    element.startDate = DateOnly.FromDateTime(DateTime.Parse(reader["START_DATE"].ToString())).ToString();
                else
                    element.startDate = "000-00-00";
                if (reader["END_DATE"].ToString() != "")
                    element.endDate = DateOnly.FromDateTime(DateTime.Parse(reader["END_DATE"].ToString())).ToString();
                else
                    element.endDate = "000-00-00";
                _listInsuranceForView.Add(element);
            }
            connection.Close();
            return _listInsuranceForView;
        }

        User IInsuranceRepository.GetById(string? insuranceId)
        {
            throw new NotImplementedException();
        }

        void IInsuranceRepository.Remove(string? insuranceId)
        {
            throw new NotImplementedException();
        }
    }
}
