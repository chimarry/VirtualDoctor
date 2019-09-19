using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Entities
{
    public class DoctorClinic : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {
        public int IdDoctor { get; set; }
        public int IdClinic { get; set; }
        public DateTime Since { get; set; }
        public DateTime? UntilDate { get; set; }
        public sbyte Deleted { get; set; }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }

        public string GetAssociatedDbTableName()
        {
            return "Doctor_Clinic";
        }

        public override int GetHashCode()
        {
            var hashCode = 1724739372;
            hashCode = hashCode * -1521134295 + IdDoctor.GetHashCode();
            hashCode = hashCode * -1521134295 + IdClinic.GetHashCode();
            hashCode = hashCode * -1521134295 + Since.GetHashCode();
            return hashCode;
        }

        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdDoctor", "IdClinic","Since" };
        }

        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }

    }
}
