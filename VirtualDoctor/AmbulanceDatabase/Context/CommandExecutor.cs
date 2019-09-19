using ALogger;
using ALogger.Factories;
using AmbulanceDatabase.Entities;
using AmbulanceDatabase.Factories;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace AmbulanceDatabase.Context
{
    public static class CommandExecutor<T> where T : IDeleteable, IUniquelyIdentifiable, IDbTableAssociate, new()
    {

        public static async Task<DbStatus> TryExecutingCRUDQuery(MySqlConnection connection, DbCommand<T> command, T entity)
        {
            MySqlCommand mysqlcommand = command.GetCommand(connection, (entity as IDbTableAssociate).GetAssociatedDbTableName(), entity);
            await mysqlcommand.ExecuteNonQueryAsync();
            return DbStatus.SUCCESS;
        }
        public static async Task<System.Data.Common.DbDataReader> TryExecutingSelectQueryDataReader(MySqlConnection connection, DbCommand<T> command, T entity = default(T))
        {

            MySqlCommand mySqlCommand = command.GetCommand(connection, (new T() as IDbTableAssociate).GetAssociatedDbTableName(), entity);
            return await mySqlCommand.ExecuteReaderAsync();
        }
        public static async Task<object> TryExecutingScalarRead(MySqlConnection connection, DbCommand<T> command, T entity = default(T))
        {

            MySqlCommand mySqlCommand = command.GetCommand(connection, (new T() as IDbTableAssociate).GetAssociatedDbTableName(), entity);
            return await mySqlCommand.ExecuteScalarAsync();
        }
    }
}
