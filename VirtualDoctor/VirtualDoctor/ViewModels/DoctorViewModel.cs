using AmbulanceDatabase;
using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDoctor.ViewModels
{
    public class DoctorViewModel
    {
        public int IdDoctor { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int WorkExperience { get; set; }
        public int IdLocalAccount { get; set; }

        public string Email { get; set; }

        private List<DoctorClinic> clinics = new List<DoctorClinic>();
        public void SetClinics(List<DoctorClinic> clinics)
        {
            this.clinics = clinics;
        }
        private List<DoctorMedicalTitle> titles = new List<DoctorMedicalTitle>();
        public void SetMedicalTitles(List<DoctorMedicalTitle> titles)
        {
            this.titles = titles;
        }
        public List<DoctorClinic> GetClinics()
        {
            return clinics;
        }
        public List<DoctorMedicalTitle> GetMedicalTitles()
        {
            return titles;
        }

    }
}
