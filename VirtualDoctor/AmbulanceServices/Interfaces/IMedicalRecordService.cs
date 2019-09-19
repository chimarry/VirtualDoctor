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
    public interface IMedicalRecordService : ICrudServiceTemplate<MedicalRecord>
    {
        Task<List<MedicalRecordsView>> GetAllViews();
        Task<List<MedicalRecordsView>> GetRangeViews(int begin, int count);
    }
}
