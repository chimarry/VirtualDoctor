using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceDatabase.Procedures;
using AmbulanceServices.Interfaces;
using AmbulanceServices.Shared;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AmbulanceServices.Services
{
    public class ClinicService : IClinicService
    {
        public async Task<DbStatus> Add(Clinic clinic)
        {
            var dbClinic = await GetByUniqueIdentifiers(new string[] { "Name", "IdPlace" }, clinic);
            DbCommand<Clinic> commandToBeExecuted;
            if (dbClinic == null)
            {
                commandToBeExecuted = new InsertCommand<Clinic>();
            }
            else if (dbClinic.Deleted == 1)
            {
                commandToBeExecuted = new InsertOrUpdateCommand<Clinic>();
            }
            else
            {
                return DbStatus.EXISTS;
            }
            return await ServiceHelper<Clinic>.ExecuteCRUDCommand(commandToBeExecuted, clinic);
        }

        public async Task<DbStatus> Delete(Clinic clinic)
        {
            return await ServiceHelper<Clinic>.ExecuteCRUDCommand(new DeleteCommand<Clinic>(), clinic);
        }
        public async Task<DbStatus> Update(Clinic clinic)
        {
            return await ServiceHelper<Clinic>.ExecuteCRUDCommand(new UpdateCommand<Clinic>(), clinic);
        }

        public async Task<IList<Clinic>> GetAll()
        {
            return await ServiceHelper<Clinic>.ExecuteSelectCommand(new SelectAllCommand<Clinic>(), null);
        }

        public async Task<Clinic> GetByPrimaryKey(Clinic clinic)
        {
            var list = await ServiceHelper<Clinic>.ExecuteSelectCommand(new SelectWithPrimaryKeyCommand<Clinic>(), clinic);
            return list.Count != 0 ? list[0] : null;
        }
        public async Task<IList<Clinic>> GetRange(int begin, int count)
        {
            return await ServiceHelper<Clinic>.ExecuteSelectCommand(new SelectWithRangeCommand<Clinic>(begin, count, "Name"));
        }

        public async Task<DbStatus> AddOrUpdate(Clinic clinic)
        {
            return await ServiceHelper<Clinic>.ExecuteCRUDCommand(new InsertOrUpdateCommand<Clinic>(), clinic);

        }

        public async Task<Clinic> GetByUniqueIdentifiers(string[] propertyNames, Clinic entity, bool? deleted = null)
        {
            var list = await ServiceHelper<Clinic>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<Clinic>(propertyNames, deleted), entity);
            return list.Count != 0 ? list[0] : null;
        }

        public async Task<string> GetClinicsName(int idClinic)
        {
            InputDbParameter inParam = new InputDbParameter("IdClinicParam", MySqlDbType.Int32, idClinic);
            DbStoredProcedure storedProcedure = new GetClinicsNameDbStoredProcedure(new InputDbParameter[] { inParam });
            return (string)(await storedProcedure.ExecuteCommand());
        }

        public async Task<int> GetTotalNumberOfItems()
        {
            return Convert.ToInt32(await ServiceHelper<Clinic>.ExecuteScalarCommand(new CountCommand<Clinic>()));
         
        }
    }
}
