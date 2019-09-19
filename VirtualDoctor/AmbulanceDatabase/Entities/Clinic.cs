using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;

namespace AmbulanceDatabase
{
    public class Clinic : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {

        public int IdClinic { get; set; }
        public string Name { get; set; }
        public int IdPlace { get; set; }

        public sbyte Deleted { get; set; }

        public string GetAssociatedDbTableName()
        {
            return "Clinic";
        }

        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdClinic" };
        }

        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            var hashCode = 875105097;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + IdPlace.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
