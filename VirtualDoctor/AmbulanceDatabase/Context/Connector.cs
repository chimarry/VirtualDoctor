using ALogger;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Context
{
    public class Connector : IConnector
    {
        private readonly ILogger logger = ALogger.Factories.LoggerFactory.CreateLogger();

        public MySqlConnection CreateConnection()
        {
            return CreateConnection(Config.Properties.Default.Ambulance);
        }
        public MySqlConnection CreateConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }

        public async Task OpenConnection(MySqlConnection connection)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
            }
            catch (MySqlException)
            {
                logger.Log(Config.Constants.Default.OpenningConnectionFailed);
            }
        }
        public async Task CloseConnection(MySqlConnection connection)
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                await connection.CloseAsync();
            }
        }
    }
}
