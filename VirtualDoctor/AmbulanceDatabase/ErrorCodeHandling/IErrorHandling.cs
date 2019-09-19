using AmbulanceDatabase.Context;
using MySql.Data.MySqlClient;

namespace AmbulanceDatabase.ErrorCodeHandling
{
    public interface IErrorHandling
    {
        DbStatus HandleException(MySqlException exception);
    }
}
