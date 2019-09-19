using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;

namespace AmbulanceDatabase
{
    public class FamilyDisease : IDeleteable, IDbTableAssociate
    {
        public int IdDisease { get; set; }
        public sbyte Chronic { get; set; }
        public sbyte Genetic { get; set; }
        public int IdMedicalRecord { get; set; }
        public sbyte Deleted { get; set; }
        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
        public string GetAssociatedDbTableName()
        {
            return "Familiy_Disease";
        }
    }
}
