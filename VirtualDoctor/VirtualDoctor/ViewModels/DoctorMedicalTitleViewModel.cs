using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDoctor.ViewModels
{
    public class DoctorMedicalTitleViewModel
    {

        private readonly IDoctorService doctorService = ServicesAmbulanceFactory.GetInstance().CreateIDoctorService();

        public int IdDoctor { get; set; }
        public int IdMedicalTitle { get; set; }
        public DateTime GettingTitleDate { get; set; }
        public string MedicalTitleName { get; set; }

        public async void SetMedicalTitleName()
        {
            MedicalTitleName = await doctorService.GetTitlesName(IdDoctor, IdMedicalTitle);
        }
        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }
        public override int GetHashCode()
        {
            var hashCode = 677826362;
            hashCode = hashCode * -1521134295 + IdDoctor.GetHashCode();
            hashCode = hashCode * -1521134295 + IdMedicalTitle.GetHashCode();
            return hashCode;
        }

    }
}
