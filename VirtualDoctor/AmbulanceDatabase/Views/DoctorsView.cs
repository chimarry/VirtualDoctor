using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Views
{
    public class DoctorsView : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {


        public int IdDoctor { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int WorkExperience { get; set; }
        public sbyte Deleted { get; set; }
        public int IdLocalAccount { get; set; }
        public string Email { get; set; }
        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
        public string GetAssociatedDbTableName()
        {
            return "Doctors_View";
        }

        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdDoctor" };
        }

    }
}

