using AmbulanceDatabase.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Context
{
    public abstract class DbCommand<T> where T : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {
        protected readonly MySqlCommand mySqlCommand = new MySqlCommand();

        private static readonly string WHITE_SPACE = " ";
        private static readonly string EQUALS_SIGN = " = ";

        public virtual MySqlCommand GetCommand(MySqlConnection connection, string tableName, T entity)
        {
            SetCommand(connection, tableName, entity);
            return mySqlCommand;
        }

        protected abstract void SetCommand(MySqlConnection connection, string tableName, T entity);

        protected static string BuildWhereExpression(T entity, string[] attributesName, bool? deleted)
        {
            StringBuilder stringBuilder = new StringBuilder(" WHERE ");
            Type entityType = entity.GetType();
            string lastPrimaryKey = attributesName.Last();
            attributesName = attributesName.TakeWhile(x => x != lastPrimaryKey).ToArray();
            foreach (string key in attributesName)
            {
                stringBuilder.Append(WHITE_SPACE + key + EQUALS_SIGN + AttributeValueHelper.IfStringDoQuotaiton(entityType.GetProperty(key).GetValue(entity)) + " AND");
            }
            stringBuilder.Append(WHITE_SPACE + lastPrimaryKey + EQUALS_SIGN + AttributeValueHelper.IfStringDoQuotaiton(entityType.GetProperty(lastPrimaryKey).GetValue(entity)));
            if (deleted != null)
            {
                stringBuilder.Append(" AND Deleted = " + Convert.ToInt32(deleted));
            }
            return stringBuilder.ToString();
        }

    }
}
