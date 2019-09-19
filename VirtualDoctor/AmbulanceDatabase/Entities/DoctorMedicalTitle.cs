using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;

namespace AmbulanceDatabase
{
    public class DoctorMedicalTitle : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {

        public int IdDoctor { get; set; }
        public int IdMedicalTitle { get; set; }
        public DateTime GettingTitleDate { get; set; }
        public sbyte Deleted { get; set; }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode()==GetHashCode();
        }

        public string GetAssociatedDbTableName()
        {
            return "Doctor_Medical_Title";
        }

        public override int GetHashCode()
        {
            var hashCode = 677826362;
            hashCode = hashCode * -1521134295 + IdDoctor.GetHashCode();
            hashCode = hashCode * -1521134295 + IdMedicalTitle.GetHashCode();
            return hashCode;
        }

        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdDoctor", "IdMedicalTitle" };
        }

        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }

    }
}
