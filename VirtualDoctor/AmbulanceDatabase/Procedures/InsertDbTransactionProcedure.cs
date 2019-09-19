using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Procedures
{
    public class InsertDbTransactionProcedure : DbTransactionProcedure
    {
        public InsertDbTransactionProcedure(string[] BodyCommands) : base(BodyCommands)
        {
        }

        protected override string GetProcedureName()
        {
            return "InsertTransactionProcedure";
        }
    }
}
