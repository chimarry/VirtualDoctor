using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Context
{
    public interface IConnector
    {
        MySqlConnection CreateConnection();
        MySqlConnection CreateConnection(string connectionString);
        Task OpenConnection(MySqlConnection connection);
        Task CloseConnection(MySqlConnection connection);
    }
}
