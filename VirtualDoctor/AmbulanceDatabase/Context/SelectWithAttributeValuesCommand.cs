using AmbulanceDatabase.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Context
{
    public class SelectWithAttributeValuesCommand<T> : DbCommand<T> where T : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {
        private readonly string[] attributeNames;
        private readonly bool? deleted;
        public SelectWithAttributeValuesCommand(string[] attributeNames)
        {
           
            this.attributeNames = attributeNames;
        }
        public SelectWithAttributeValuesCommand(string[] attributeNames,bool? deleted):this(attributeNames)
        {
            this.deleted = deleted;  
        }
        protected override void SetCommand(MySqlConnection connection, string tableName, T entity)
        {
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandText = BuildCommandText(tableName, entity);
        }
        private string BuildCommandText(string tableName, T entity)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT * FROM " + tableName);
            string whereExpression = DbCommand<T>.BuildWhereExpression(entity, attributeNames, deleted);
            return stringBuilder.Append(whereExpression).ToString();
        }
    }
}
