using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmbulanceDatabase.Context;
using MySql.Data.MySqlClient;

namespace AmbulanceDatabase.Procedures
{
    public class GetTitlesNameDbStoredProcedure : DbStoredProcedure
    {
        public GetTitlesNameDbStoredProcedure(DbParameter[] inputParams, DbParameter[] outputParams = null) : base(inputParams, outputParams)
        {
        }

        protected async override Task<object> Execute(MySqlCommand command)
        {
            string name = string.Empty;
            DataTable dataTable = new DataTable();
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
            {
                await dataAdapter.FillAsync(dataTable);
            }
            if (dataTable.Rows.Count != 0)
            {
                name = dataTable.Rows[0].Field<string>("TitlesName");
            }
            return name;
        }

        protected override string GetStoredProcedureName()
        {
            return "GetTitlesName";
        }
    }
}
