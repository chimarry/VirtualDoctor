using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Context
{
    public class DbParameter
    {
        protected readonly MySqlParameter mySqlParameter;
        public DbParameter(string name, MySqlDbType type, object value)
        {
            mySqlParameter = new MySqlParameter(name, type);
            mySqlParameter.Value = value;
        }
        public MySqlParameter GetParameter()
        {
            return mySqlParameter;
        }
    }
}
