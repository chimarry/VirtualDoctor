using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceDatabase.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceServices.Interfaces
{
    public interface IDoctorService : ICrudServiceTemplate<Doctor>
    {
        Task<IList<DoctorsView>> GetAllViews();

        Task<IList<DoctorsView>> GetRangeViews(int begin, int count);
        Task<string> GetTitlesName(int idDoctor, int idMedicalTitle);
    }
}
