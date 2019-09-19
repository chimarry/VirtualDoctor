using AmbulanceDatabase.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Context
{
    public class CompletelyDeleteCommand<T> : DbCommand<T> where T : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {
        public static readonly string WHITE_SPACE = " ";
        public static readonly string EQUALS_SIGN = " = ";
        protected override void SetCommand(MySqlConnection connection, string tableName, T entity)
        {
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandText = BuildCommandText(tableName, entity);
        }

        private string BuildCommandText(string tableName, T entity)
        {
            StringBuilder stringBuilder = new StringBuilder(" DELETE FROM " + tableName);
            //string whereExpression = DbCommand<T>.BuildWherePrimaryKeyExpression(entity, null);
            string whereExpression = DbCommand<T>.BuildWhereExpression(entity, entity.GetPrimaryKeyPropertyNames(), null);
          
            return stringBuilder.Append(whereExpression).ToString();
        }
    }
}
