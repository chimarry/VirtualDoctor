using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AmbulanceDatabase.Context
{
    public class InputDbParameter : DbParameter
    {
        public InputDbParameter(string name, MySqlDbType type, object value) : base(name, type, value)
        {
            mySqlParameter.Direction = System.Data.ParameterDirection.Input;
        }
    }
}
