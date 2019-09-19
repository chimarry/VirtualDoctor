using AmbulanceDatabase.Context;
using AmbulanceDatabase.Procedures;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDoctor.ViewModels
{
    public class ClinicViewModel
    {
        private readonly IClinicService clinicService = ServicesAmbulanceFactory.GetInstance().CreateIClinicService();

        public int IdClinic { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public int IdPlace { get; set; }


        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            var hashCode = 875105097;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + IdPlace.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Name + " : " + Place;
        }
    }
}
