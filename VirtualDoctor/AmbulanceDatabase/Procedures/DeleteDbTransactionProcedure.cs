using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Procedures
{
    public class DeleteDbTransactionProcedure : DbTransactionProcedure
    {
        public DeleteDbTransactionProcedure(string[] BodyCommands) : base(BodyCommands)
        {
        }

        protected override string GetProcedureName()
        {
            return "DeletedDbTransactionProcedure";
        }
    }
}
