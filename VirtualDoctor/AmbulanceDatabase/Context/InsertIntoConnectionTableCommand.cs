using AmbulanceDatabase.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AmbulanceDatabase.Context
{
    public class InsertIntoConnectionTableCommand<T> : DbCommand<T> where T : IDeleteable, IUniquelyIdentifiable, IDbTableAssociate
    {
        public static readonly string OPENNING_BRACKET = "(";
        public static readonly string CLOSING_BRACKET = ")";
        public static readonly string WHITE_SPACE = " ";
        public static readonly string COMMA = ",";
        private readonly string attributeNameLastAutoIncrement;
        public InsertIntoConnectionTableCommand(string attributeNameLastAutoIncrement)
        {
            this.attributeNameLastAutoIncrement = attributeNameLastAutoIncrement;
        }
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
            propertiesInfo = propertiesInfo.Where(x => x.Name.CompareTo(attributeNameLastAutoIncrement) != 0).ToArray();
            for (int i = 0; i < propertiesInfo.Length; ++i)
            {
                stringBuilderColumnNames.Append(propertiesInfo[i].Name + COMMA);
                stringBuilderCorespondingValues.Append(AttributeValueHelper.IfStringDoQuotaiton(propertiesInfo[i].GetValue(modelEntity)) + COMMA);
            }
            stringBuilderColumnNames.Append(attributeNameLastAutoIncrement + CLOSING_BRACKET);
            stringBuilderCorespondingValues.Append("LAST_INSERT_ID() " + CLOSING_BRACKET);
            stringBuilderColumnNames.Append(" VALUES " + stringBuilderCorespondingValues.ToString());
            return stringBuilderColumnNames.ToString();
        }
    }
}
