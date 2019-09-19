using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Procedures
{
    public class GetActiveLocalAccountsDbStoredProcedure : DbStoredProcedure
    {
        public GetActiveLocalAccountsDbStoredProcedure(DbParameter[] inputParams, DbParameter[] outputParams = null) : base(inputParams, outputParams)
        {
        }

        protected async override Task<object> Execute(MySqlCommand command)
        {
            List<LocalAccount> localAccounts = new List<LocalAccount>();
            DataTable dataTable = new DataTable();
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
            {
                await dataAdapter.FillAsync(dataTable);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                LocalAccount localAccount = new LocalAccount()
                {
                    IdLocalAccount = (int)row["IdLocalAccount"],
                    FullName = (string)row["FullName"],
                    Deleted = (sbyte)row["Deleted"],
                    Email = (string)row["Email"],
                    PasswordHash = (string)row["PasswordHash"]
                };
                localAccount.SetRoleNames((string)row["Roles"]);
                localAccounts.Add(localAccount);
            }
            return localAccounts;

        }

        protected override string GetStoredProcedureName()
        {
            return "GetActiveLocalAccounts";
        }
    }
}
