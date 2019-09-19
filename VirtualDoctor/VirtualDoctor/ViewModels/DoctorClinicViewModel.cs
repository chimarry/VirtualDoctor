using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDoctor.ViewModels
{
    public class DoctorClinicViewModel
    {
        private readonly IClinicService clinicService = ServicesAmbulanceFactory.GetInstance().CreateIClinicService();
        private int _idClinic;
        public int IdDoctor { get; set; }
        public int IdClinic
        {
            get
            {
                return _idClinic;
            }
            set
            {
                _idClinic = value;
                if (_idClinic != 0)
                {
                    AddClinicsName();
                }
            }
        }
        public DateTime Since { get; set; }
        public DateTime? UntilDate { get; set; }

        public string ClinicsName { get; private set; }

        private async void AddClinicsName()
        {
            ClinicsName = await clinicService.GetClinicsName(IdClinic);
        }
        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }
        public override int GetHashCode()
        {
            var hashCode = 1724739372;
            hashCode = hashCode * -1521134295 + IdDoctor.GetHashCode();
            hashCode = hashCode * -1521134295 + IdClinic.GetHashCode();
            hashCode = hashCode * -1521134295 + Since.GetHashCode();
            return hashCode;
        }


    }
}
