using ALogger;
using ALogger.Factories;
using AmbulanceDatabase.Context;
using MySql.Data.MySqlClient;
using System;

namespace AmbulanceDatabase.ErrorCodeHandling
{
    public class ErrorCodeHandler : IErrorHandling
    {
        private static readonly ILogger logger = LoggerFactory.CreateLogger();
        private static readonly string NO_SUCH_TABLE = "Used table could not be found.";
        private static readonly string OUT_OF_RESOURCES = "The server is out of resources, check if MySql or some other process is using all available memory.";
        private static readonly string NO_SORT_MEMORY = "The server is out of sort-memory, the sort buffer size should be increased.";
        private static readonly string UNKNOWN_COMMAND = "The command is unknown.";
        private static readonly string DUPLICATE_KEY = "There is already a key with the given values.";
        private static readonly string KEY_NOT_FOUND = "The specified key was not found.";
        private static readonly string TABLE_NOT_LOCKED_FOR_WRITE = "The specified table was locked with a READ lock, and can't be updated.";
        private static readonly string WRONG_TABLE_NAME = "The specified table name is incorrect.";
        private static readonly string BAD_FIELD_NAME = "The specified columns is unknown.";
        private static readonly string DUPLICATE_KEY_ENTRY = "Unique columns must have values that are not already present in table";
        private static readonly string ERROR_NOT_KNOWN = "Database error.";
        public DbStatus HandleException(MySqlException exception)
        {
            switch (exception.Number)
            {
                case (int)MySqlErrorCode.NoSuchTable:
                    logger.Log(CreateLogMessage(exception, NO_SUCH_TABLE)); return DbStatus.DATABASE_ERROR;

                case (int)MySqlErrorCode.OutOfResources:
                    logger.Log(CreateLogMessage(exception, OUT_OF_RESOURCES)); return DbStatus.DATABASE_ERROR;

                case (int)MySqlErrorCode.OutOfSortMemory:
                    logger.Log(CreateLogMessage(exception, NO_SORT_MEMORY)); return DbStatus.DATABASE_ERROR;

                case (int)MySqlErrorCode.UnknownCommand:
                    logger.Log(CreateLogMessage(exception, UNKNOWN_COMMAND)); return DbStatus.DATABASE_ERROR;

                case (int)MySqlErrorCode.DuplicateKey:
                    logger.Log(CreateLogMessage(exception, DUPLICATE_KEY)); return DbStatus.EXISTS;

                case (int)MySqlErrorCode.KeyNotFound:
                    logger.Log(CreateLogMessage(exception, KEY_NOT_FOUND)); return DbStatus.NOT_FOUND;

                case (int)MySqlErrorCode.TableNotLockedForWrite:
                    logger.Log(CreateLogMessage(exception, TABLE_NOT_LOCKED_FOR_WRITE)); return DbStatus.DATABASE_ERROR;

                case (int)MySqlErrorCode.WrongTableName:
                    logger.Log(CreateLogMessage(exception, WRONG_TABLE_NAME)); return DbStatus.DATABASE_ERROR;

                case (int)MySqlErrorCode.BadFieldError:
                    logger.Log(CreateLogMessage(exception, BAD_FIELD_NAME)); return DbStatus.DATABASE_ERROR;
                case (int)MySqlErrorCode.DuplicateKeyEntry:
                    logger.Log(CreateLogMessage(exception, DUPLICATE_KEY_ENTRY)); return DbStatus.EXISTS;
                default:
                    logger.Log(CreateLogMessage(exception, ERROR_NOT_KNOWN)); return DbStatus.DATABASE_ERROR;

            }
        }
        private string CreateLogMessage(MySqlException ex, string personalMessage)
        {
            return Environment.NewLine + personalMessage + Environment.NewLine + "Error code:" + ex.Code + Environment.NewLine + ex.Message;
        }
    }
}
