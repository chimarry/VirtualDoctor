using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmbulanceDatabase.Entities;
using MySql.Data.MySqlClient;

namespace AmbulanceDatabase.Context
{
    public class SelectWithPrimaryKeyCommand<T> : DbCommand<T> where T : IDeleteable, IUniquelyIdentifiable, IDbTableAssociate
    {
        protected override void SetCommand (MySqlConnection connection, string tableName, T entity)
        {
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandText = BuildCommandText(tableName, entity);
        }
        private string BuildCommandText(string tableName, T entity)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT * FROM " + tableName);
            // string whereExpression = DbCommand<T>.BuildWherePrimaryKeyExpression(entity, false);
            string whereExpression = DbCommand<T>.BuildWhereExpression(entity, entity.GetPrimaryKeyPropertyNames(), false);
            return stringBuilder.Append(whereExpression).ToString();
        }
    }
}
