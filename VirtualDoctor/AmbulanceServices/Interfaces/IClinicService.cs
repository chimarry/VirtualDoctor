using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceServices.Interfaces
{
    public interface IClinicService : ICrudServiceTemplate<Clinic>
    {
        Task<string> GetClinicsName(int idClinic);
    }
}
