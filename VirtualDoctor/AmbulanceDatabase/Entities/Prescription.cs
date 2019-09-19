using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;

namespace AmbulanceDatabase
{
    public class Prescription : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {
        public int IdPrescription { get; set; }
        public string ConsumationDetails { get; set; }
        public DateTime DateOfPrescripting { get; set; }
        public int IdDisease { get; set; }
        public string DrugInn { get; set; }
        public DateTime AppreanceDate { get; set; }
        public int IdMedicalRecord { get; set; }
        public int IdDoctor { get; set; }
        public string Usability { get; set; }
        public sbyte Deleted { get; set; }
        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
        public string GetAssociatedDbTableName()
        {
            return "Prescription";
        }

        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdPrescription" };
        }
    }
}
