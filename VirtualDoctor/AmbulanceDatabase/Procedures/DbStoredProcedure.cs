using AmbulanceDatabase.Context;
using AmbulanceDatabase.ErrorCodeHandling;
using AmbulanceDatabase.Factories;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Procedures
{
    public abstract class DbStoredProcedure
    {
        protected readonly DbParameter[] inputParameters;
        protected readonly DbParameter[] outputParameters;
        private readonly IConnector connector = ConnectorFactory.CreateConnector();
        private readonly IErrorHandling errorHandler = ErrorHandlerFactory.CreateErrorHandler();
        public DbStoredProcedure(DbParameter[] inputParams, DbParameter[] outputParams = default(DbParameter[]))
        {
            this.inputParameters = inputParams;
            this.outputParameters = outputParams ?? new DbParameter[0];
        }
        public async Task<object> ExecuteCommand()
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = connector.CreateConnection();
            try
            {
                await connector.OpenConnection(connection);
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(SetParameters());
                command.CommandText = GetStoredProcedureName();
                return await Execute(command);
            }
            catch (MySqlException ex)
            {
                errorHandler.HandleException(ex);
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                await connector.CloseConnection(connection);
            }
        }
        protected virtual MySqlParameter[] SetParameters()
        {
            MySqlParameter[] mySqlParameters = new MySqlParameter[inputParameters.Length + outputParameters.Length];
            for (int i = 0; i < inputParameters.Length; ++i)
            {
                mySqlParameters[i] = inputParameters[i].GetParameter();
            }
            for (int i = inputParameters.Length; i < outputParameters.Length + inputParameters.Length; ++i)
            {
                mySqlParameters[i] = outputParameters[i].GetParameter();
            }
            return mySqlParameters;
        }
        protected abstract Task<object> Execute(MySqlCommand command);
        protected abstract string GetStoredProcedureName();
    }
}
