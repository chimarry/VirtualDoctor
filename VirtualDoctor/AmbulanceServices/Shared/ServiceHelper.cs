using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using AmbulanceDatabase.ErrorCodeHandling;
using AmbulanceDatabase.Factories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace AmbulanceServices.Shared
{
    public static class ServiceHelper<T> where T : IDeleteable, IUniquelyIdentifiable, IDbTableAssociate, new()
    {

        public async static Task<DbStatus> ExecuteCRUDCommand(DbCommand<T> command, T entity)
        {

            IConnector connector = ConnectorFactory.CreateConnector();
            IErrorHandling errorHandler = ErrorHandlerFactory.CreateErrorHandler();

            MySqlConnection connection = connector.CreateConnection();

            try
            {
                await connector.OpenConnection(connection);
                return await CommandExecutor<T>.TryExecutingCRUDQuery(connection, command, entity);
            }
            catch (MySqlException exception)
            {

                return errorHandler.HandleException(exception);

            }
            finally
            {
                await connector.CloseConnection(connection);
            }
        }
        public async static Task<List<T>> ExecuteSelectCommand(DbCommand<T> command, T entity = default(T))
        {

            IConnector connector = ConnectorFactory.CreateConnector();
            IErrorHandling errorHandler = ErrorHandlerFactory.CreateErrorHandler();

            List<T> clinics = new List<T>();

            MySqlConnection connection = connector.CreateConnection();
            try
            {
                await connector.OpenConnection(connection);
                var reader = await CommandExecutor<T>.TryExecutingSelectQueryDataReader(connection, command, entity);
                while (await reader.ReadAsync())
                {
                    clinics.Add(ReadOneObject(reader));
                }
                return clinics;
            }

            catch (MySqlException exception)
            {
                errorHandler.HandleException(exception);
                return clinics;
            }
            finally
            {
                await connector.CloseConnection(connection);
            }
        }
        public async static Task<object> ExecuteScalarCommand(DbCommand<T> command)
        {

            IConnector connector = ConnectorFactory.CreateConnector();
            IErrorHandling errorHandler = ErrorHandlerFactory.CreateErrorHandler();

            object scalarResult = null;
            MySqlConnection connection = connector.CreateConnection();
            try
            {
                await connector.OpenConnection(connection);
                scalarResult = await CommandExecutor<T>.TryExecutingScalarRead(connection, command);
                return scalarResult;
            }

            catch (MySqlException exception)
            {
                errorHandler.HandleException(exception);
                return scalarResult;
            }
            finally
            {
                await connector.CloseConnection(connection);
            }
        }
        private static T ReadOneObject(System.Data.Common.DbDataReader reader)
        {
            T obj = default(T);

            obj = Activator.CreateInstance<T>();
            var properties = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {

                if (!Equals(reader[prop.Name], DBNull.Value))
                {

                    prop.SetValue(obj, reader[prop.Name], null);
                }

            }
            return obj;
        }

    }
}
