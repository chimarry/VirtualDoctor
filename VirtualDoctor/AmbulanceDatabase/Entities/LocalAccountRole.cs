using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Entities
{

    public class LocalAccountRole : IDbTableAssociate, IDeleteable, IUniquelyIdentifiable
    {
        public int IdRole { get; set; }
        public int IdLocalAccount { get; set; }
        public sbyte Deleted { get; set; }
        public string GetAssociatedDbTableName()
        {
            return "Local_Account_Role";
        }
        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdRole", "IdLocalAccount" };
        }

        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
    }
}
