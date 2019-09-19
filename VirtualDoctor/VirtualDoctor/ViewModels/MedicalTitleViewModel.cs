using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDoctor.ViewModels
{
    public class MedicalTitleViewModel
    {
        public int IdMedicalTitle { get; set; }
        public string Name { get; set; }

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
            var hashCode = -200233715;
            hashCode = hashCode * -1521134295 + IdMedicalTitle.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
