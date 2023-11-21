using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace HumanResourcesApplication_DoAn.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "server=sql12.freesqldatabase.com; user=sql12663180; password=HgfskhILms; database=sql12663180";
        }

        protected MySqlConnection GetMySqlConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
