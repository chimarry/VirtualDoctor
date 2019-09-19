using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceServices.Interfaces;
using AmbulanceServices.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmbulanceServices.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        public async Task<DbStatus> Add(Prescription prescription)
        {
            return await ServiceHelper<Prescription>.ExecuteCRUDCommand(new InsertCommand<Prescription>(), prescription);
        }

        public async Task<DbStatus> Delete(Prescription prescription)
        {
            return await ServiceHelper<Prescription>.ExecuteCRUDCommand(new DeleteCommand<Prescription>(), prescription);
        }
        public async Task<DbStatus> Update(Prescription prescription)
        {
            return await ServiceHelper<Prescription>.ExecuteCRUDCommand(new UpdateCommand<Prescription>(), prescription);
        }

        public async Task<IList<Prescription>> GetAll()
        {
            return await ServiceHelper<Prescription>.ExecuteSelectCommand(new SelectAllCommand<Prescription>());
        }

        public async Task<Prescription> GetByPrimaryKey(Prescription prescription)
        {
            var list = await ServiceHelper<Prescription>.ExecuteSelectCommand(new SelectWithPrimaryKeyCommand<Prescription>(), prescription);
            return list.Count != 0 ? list[0] : null;
        }
        public Task<Prescription> GetByUniqueIdentifiers(params object[] identifiers)
        {
            throw new NotImplementedException();
        }

        public async Task<DbStatus> AddOrUpdate(Prescription prescription)
        {
            return await ServiceHelper<Prescription>.ExecuteCRUDCommand(new InsertOrUpdateCommand<Prescription>(), prescription);
        }
    }
}
