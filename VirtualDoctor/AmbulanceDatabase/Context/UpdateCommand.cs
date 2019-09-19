using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AmbulanceDatabase.Entities;
using MySql.Data.MySqlClient;

namespace AmbulanceDatabase.Context
{
    public class UpdateCommand<T> : DbCommand<T> where T : IDeleteable, IUniquelyIdentifiable, IDbTableAssociate
    {
        public static readonly string OPENNING_BRACKET = "(";
        public static readonly string CLOSING_BRACKET = ")";
        public static readonly string WHITE_SPACE = " ";
        public static readonly string COMMA = ",";
        public static readonly string EQUALS = "=";
        protected override void SetCommand(MySqlConnection connection, string tableName, T entity)
        {
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandText = BuildCommandText(tableName, entity);
        }
        private string BuildCommandText(string tableName, T entity)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE ");
            stringBuilder.Append(tableName + WHITE_SPACE);
            stringBuilder.Append(BuildVariableCommandText(entity));
            return stringBuilder.ToString(); 

        }
        private string BuildVariableCommandText(T modelEntity)
        {
            StringBuilder stringBuilder = new StringBuilder(WHITE_SPACE + "SET" + WHITE_SPACE);
            Type entityType = modelEntity.GetType();
            PropertyInfo[] propertiesInfo = entityType.GetProperties();


            for (int i = 0; i < propertiesInfo.Length - 1; ++i)
            {
                stringBuilder.Append(propertiesInfo[i].Name + EQUALS + AttributeValueHelper.IfStringDoQuotaiton(propertiesInfo[i].GetValue(modelEntity)) + WHITE_SPACE + COMMA);
            }
            stringBuilder.Append(propertiesInfo.Last().Name + EQUALS + AttributeValueHelper.IfStringDoQuotaiton(propertiesInfo.Last().GetValue(modelEntity)) + WHITE_SPACE);
            string whereExpression = DbCommand<T>.BuildWhereExpression(modelEntity, modelEntity.GetPrimaryKeyPropertyNames(), false);
            return stringBuilder.Append(whereExpression).ToString();
        }

    }
}
