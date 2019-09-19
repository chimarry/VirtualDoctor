using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;

namespace AmbulanceDatabase
{
    public class Disease : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {

        public int IdDisease { get; set; }
        public string SerbianName { get; set; }
        public string LatinName { get; set; }
        public int IdDiseaseTypeIcd { get; set; }
        public sbyte Chronic { get; set; }
        public sbyte Genetic { get; set; }
        public string Definition { get; set; }
        public string Aliases { get; set; }
        public sbyte Deleted { get; set; }

        public string GetAssociatedDbTableName()
        {
            return "Disease";
        }
        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdDisease" };
        }

        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
    }
}
