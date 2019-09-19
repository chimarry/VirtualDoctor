using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Entities
{
    public interface IDbTableAssociate
    {
        string GetAssociatedDbTableName();
    }
}
