using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;

using System.Windows.Media;

namespace AmbulanceDatabase
{
    public class TestResults : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {

        //[Column(Typeface="json")]
        public string TestStructure { get; set; }
        public int IdTestResults { get; set; }
        public string TypeOfTest { get; set; }
        public sbyte Deleted { get; set; }
        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
        public string GetAssociatedDbTableName()
        {
            return "Test_Results";
        }

        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdTestResults" };
        }
    }
}
