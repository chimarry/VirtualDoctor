using AmbulanceDatabase.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Context
{
    public class SelectWithRangeCommand<T> : DbCommand<T> where T : IDeleteable, IUniquelyIdentifiable, IDbTableAssociate
    {
        private readonly int offset;
        private readonly int limit;
        private readonly string orderByAttribute;

        public SelectWithRangeCommand(int offset, int limit, string orderByAttribute)
        {
            this.orderByAttribute = orderByAttribute;
            this.offset = offset;
            this.limit = limit;
        }


        protected override void SetCommand(MySqlConnection connection, string tableName, T entity)
        {
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandText = "SELECT * FROM " + tableName + " WHERE deleted = 0  ORDER BY " + orderByAttribute + " LIMIT " + limit + " OFFSET " + offset;
        }
    }
}
