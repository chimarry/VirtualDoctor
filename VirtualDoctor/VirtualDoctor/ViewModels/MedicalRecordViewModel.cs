using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDoctor.ViewModels
{
    public class MedicalRecordViewModel
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
        public string ResidenceName { get; set; }

    }
}
