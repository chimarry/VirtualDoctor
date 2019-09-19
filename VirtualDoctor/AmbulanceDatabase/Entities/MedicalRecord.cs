using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;

namespace AmbulanceDatabase
{
    public class MedicalRecord : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {
        public int IdMedicalRecord { get; set; }
 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Jmb { get; set; }
        public sbyte Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public sbyte MarriageStatus { get; set; }
        public string MothersFullName { get; set; }
        public string FathersFullName { get; set; }
        public string MothersProfession { get; set; }
        public string FathersProfession { get; set; }
        public string InsuranceNumber { get; set; }
        public int IdResidence { get; set; }
        public sbyte Deleted { get; set; }

        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
        public string GetAssociatedDbTableName()
        {
            return "Medical_Record";
        }

        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdMedicalRecord" };
        }
    }
}
