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
    public class InsertCommand<T> : DbCommand<T> where T : IDeleteable, IUniquelyIdentifiable, IDbTableAssociate
    {
        public static readonly string OPENNING_BRACKET = "(";
        public static readonly string CLOSING_BRACKET = ")";
        public static readonly string WHITE_SPACE = " ";
        public static readonly string COMMA = ",";
        protected override void SetCommand(MySqlConnection connection, string tableName, T entity)
        {
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandText = BuildCommandText(tableName, entity);
        }
        private string BuildCommandText(string tableName, T entity)
        {
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO ");
            stringBuilder.Append(tableName + WHITE_SPACE);
            return stringBuilder.Append(BuildVariableCommandText(tableName, entity)).ToString();

        }
        private string BuildVariableCommandText(string tableName, T modelEntity)
        {
            StringBuilder stringBuilderColumnNames = new StringBuilder(WHITE_SPACE + OPENNING_BRACKET + WHITE_SPACE);
            StringBuilder stringBuilderCorespondingValues = new StringBuilder(WHITE_SPACE + OPENNING_BRACKET + WHITE_SPACE);
            Type entityType = modelEntity.GetType();
            PropertyInfo[] propertiesInfo = entityType.GetProperties();
            propertiesInfo = propertiesInfo.Where(x => x.Name.CompareTo(modelEntity.GetPrimaryKeyPropertyNames().First()) != 0).ToArray();
            for (int i = 0; i < propertiesInfo.Length - 1; ++i)
            {
                stringBuilderColumnNames.Append(propertiesInfo[i].Name + COMMA);
                stringBuilderCorespondingValues.Append(AttributeValueHelper.IfStringDoQuotaiton(propertiesInfo[i].GetValue(modelEntity)) + COMMA);
            }
            stringBuilderColumnNames.Append(propertiesInfo.Last().Name + CLOSING_BRACKET);
            stringBuilderCorespondingValues.Append(AttributeValueHelper.IfStringDoQuotaiton(propertiesInfo.Last().GetValue(modelEntity)) + CLOSING_BRACKET);
            stringBuilderColumnNames.Append(" VALUES " + stringBuilderCorespondingValues.ToString());
            return stringBuilderColumnNames.ToString();
        }
        private string EnitiesId(string entityTableName)
        {
            return "Id" + entityTableName;
        }

    }
}
