using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Procedures
{
    public class UpdateDbTransactionProcedure : DbTransactionProcedure
    {
        public UpdateDbTransactionProcedure(string[] BodyCommands) : base(BodyCommands)
        {
        }

        protected override string GetProcedureName()
        {

            return "UpdateDbTransactionProcedure";
        }
    }
}
