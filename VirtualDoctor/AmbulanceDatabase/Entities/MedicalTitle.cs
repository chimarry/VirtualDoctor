using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;

namespace AmbulanceDatabase
{
    public class MedicalTitle : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {


        public int IdMedicalTitle { get; set; }
        public string Name { get; set; }
        public sbyte Deleted { get; set; }
        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
        public string GetAssociatedDbTableName()
        {
            return "Medical_Title";
        }

        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdMedicalTitle" };
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
