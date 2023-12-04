using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        protected MySqlConnection connection;
        public RepositoryBase()
        {
            //_connectionString = "server=sql12.freesqldatabase.com; user=sql12665837; password=2ZTBmbHdJ5; database=sql12665837; convert zero datetime=True";
            //connection = new MySqlConnection(_connectionString);
            //try
            //{
            //    connection.Open();
            //}
            //catch (Exception ex)
            //{

            //}
            _connectionString = "server=sql12.freesqldatabase.com; user=sql12667056; password=nmzAiqwB65; database=sql12667056; convert zero datetime=True";
            connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        } 
    }
}
