using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmbulanceDatabase.Entities;
using MySql.Data.MySqlClient;

namespace AmbulanceDatabase.Context
{
    public class DeleteCommand<T> : DbCommand<T> where T : IDeleteable, IUniquelyIdentifiable, IDbTableAssociate
    {
        public override MySqlCommand GetCommand(MySqlConnection connection, string tableName, T entity)
        {
            try
            {
                entity.SetDeletedEntity(true);
                return new UpdateCommand<T>().GetCommand(connection, tableName, entity);
            }
            catch (Exception)
            {
                return new CompletelyDeleteCommand<T>().GetCommand(connection, tableName, entity);

            }
        }
        protected override void SetCommand(MySqlConnection connection, string tableName, T entity)
        {

        }
    }
}
