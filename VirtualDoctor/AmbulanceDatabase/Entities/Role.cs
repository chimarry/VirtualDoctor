using System;
using System.Collections.Generic;

namespace AmbulanceDatabase.Entities
{
    public class Role : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {
        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public sbyte Deleted { get; set; }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }

        public string GetAssociatedDbTableName()
        {
            return "Role";
        }

        public override int GetHashCode()
        {
            var hashCode = 2065429282;
            hashCode = hashCode * -1521134295 + IdRole.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RoleName);
            return hashCode;
        }

        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdRole" };
        }

        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }

    }
}
