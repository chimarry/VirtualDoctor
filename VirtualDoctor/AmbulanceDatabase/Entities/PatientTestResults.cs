using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;

namespace AmbulanceDatabase
{
    public class PatientTestResults : IDeleteable, IDbTableAssociate
    {
        public int IdMedicalRecord { get; set; }
        public int IdTestResults { get; set; }
        public DateTime DateWhenTaken { get; set; }
        public sbyte Deleted { get; set; }
        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
        public string GetAssociatedDbTableName()
        {
            return "Patient_Test_Results";
        }
    }
}
