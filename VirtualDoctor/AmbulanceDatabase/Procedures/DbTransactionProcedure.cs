using AmbulanceDatabase.Context;
using AmbulanceDatabase.ErrorCodeHandling;
using AmbulanceDatabase.Factories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Procedures
{
    public abstract class DbTransactionProcedure
    {
        public string CommandText { get; set; }
        public static string DELIMITER = ";";
        private readonly IConnector connector = ConnectorFactory.CreateConnector();
        private readonly IErrorHandling errorHandler = ErrorHandlerFactory.CreateErrorHandler();
        public DbTransactionProcedure(string[] BodyCommands)
        {
            CommandText = BuildCommandText(BodyCommands);
        }
        private string BuildCommandText(string[] BodyCommands)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string dropProcedure = "DROP PROCEDURE IF EXISTS " + GetProcedureName() + DELIMITER + Environment.NewLine;
            stringBuilder.Append(dropProcedure);
            string createProcedure = /*"DELIMITER $$" +*/ Environment.NewLine + " CREATE PROCEDURE " + GetProcedureName() + "( )" + Environment.NewLine + " BEGIN ";
            stringBuilder.Append(createProcedure);
            string addHandler = "DECLARE EXIT HANDLER FOR SQLEXCEPTION" + Environment.NewLine + " BEGIN " +
                Environment.NewLine + "ROLLBACK;" + Environment.NewLine + "RESIGNAL;" + Environment.NewLine + "END;";
            stringBuilder.Append(addHandler);
            string setAutocommit = Environment.NewLine + " set autocommit = 0;" + Environment.NewLine;
            stringBuilder.Append(setAutocommit);
            string startTransaction = "START TRANSACTION;" + Environment.NewLine;
            stringBuilder.Append(startTransaction);
            foreach (string command in BodyCommands)
            {
                stringBuilder.Append(command + DELIMITER + Environment.NewLine);
            }
            string commitEnd = "COMMIT;" + Environment.NewLine + "END" + Environment.NewLine /*+ "DELIMITER ;"*/;
            stringBuilder.Append(commitEnd);
            return stringBuilder.ToString();

        }
        public async Task<DbStatus> Execute()
        {

            MySqlConnection connection = connector.CreateConnection();
            try
            {
                await connector.OpenConnection(connection);
                await CreateProcedure(connection);
                MySqlCommand callCommand = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = GetProcedureName()
                };
                await callCommand.ExecuteNonQueryAsync();
                return DbStatus.SUCCESS;
            }
            catch (MySqlException ex)
            {
                return errorHandler.HandleException(ex);

            }
            catch (Exception)
            {
                return DbStatus.DATABASE_ERROR;
            }
            finally
            {
                await connector.CloseConnection(connection);
            }
        }
        private async Task CreateProcedure(MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand
            {
                Connection = connection,
                CommandText = CommandText
            };
            await command.ExecuteNonQueryAsync();
        }

        protected abstract string GetProcedureName();
    }
}
