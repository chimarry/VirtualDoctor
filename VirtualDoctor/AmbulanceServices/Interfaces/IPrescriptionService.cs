using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceServices.Interfaces
{
    public interface IPrescriptionService
    {
        Task<DbStatus> Add(Prescription prescription);
        Task<DbStatus> AddOrUpdate(Prescription prescription);

        Task<DbStatus> Delete(Prescription prescription);

        Task<DbStatus> Update(Prescription prescription);

        Task<Prescription> GetByPrimaryKey(Prescription prescription);
        Task<IList<Prescription>> GetAll();
        Task<Prescription> GetByUniqueIdentifiers(params object[] identifiers);
    }
}
