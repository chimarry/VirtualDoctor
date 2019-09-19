using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Procedures
{
    public class GetRolesWithIdLocalAccountDbStoredProcedure : DbStoredProcedure
    {
        public GetRolesWithIdLocalAccountDbStoredProcedure(DbParameter[] inputParams, DbParameter[] outputParams = null) : base(inputParams, outputParams)
        {
        }


        protected async override Task<object> Execute(MySqlCommand command)
        {
            DataTable dataTable = new DataTable();
            List<Role> roles = new List<Role>();
           
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
            {
                await dataAdapter.FillAsync(dataTable);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                Role role = new Role()
                {
                    IdRole = (int)row["IdRole"],
                    RoleName = (string)row["RoleName"],
                    Deleted = (sbyte)row["Deleted"]
                };
                roles.Add(role);
            }
            return roles;
        }

        protected override string GetStoredProcedureName()
        {
            return "GetRolesWithIdLocalAccount";
        }
    }
}
