using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmbulanceDatabase.Entities;
using MySql.Data.MySqlClient;

namespace AmbulanceDatabase.Context
{
    public class CustomCommand<T> : DbCommand<T> where T : IDeleteable, IUniquelyIdentifiable, IDbTableAssociate
    {
        public override MySqlCommand GetCommand(MySqlConnection connection, string command, T entity)
        {

            SetCommand(connection, command, entity);
            return mySqlCommand;
        }

        protected override void SetCommand(MySqlConnection connection, string command, T entity)
        {
            mySqlCommand.Connection = connection;
            mySqlCommand.CommandText = command;
        }
    }
}
