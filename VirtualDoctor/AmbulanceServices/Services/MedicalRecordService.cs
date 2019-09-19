using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceDatabase.Views;
using AmbulanceServices.Interfaces;
using AmbulanceServices.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmbulanceServices.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        public async Task<DbStatus> Add(MedicalRecord medicalRecord)
        {
            var dbMedicalRecord = await GetByUniqueIdentifiers(new string[] { "Jmb" }, medicalRecord);
            DbCommand<MedicalRecord> commandToBeExecuted;
            if (dbMedicalRecord == null)
            {
                commandToBeExecuted = new InsertCommand<MedicalRecord>();
            }
            else if (dbMedicalRecord.Deleted == 1)
            {
                commandToBeExecuted = new InsertOrUpdateCommand<MedicalRecord>();
            }
            else
            {
                return DbStatus.EXISTS;
            }
            return await ServiceHelper<MedicalRecord>.ExecuteCRUDCommand(commandToBeExecuted, medicalRecord);

        }

        public async Task<DbStatus> Delete(MedicalRecord medicalRecord)
        {
            return await ServiceHelper<MedicalRecord>.ExecuteCRUDCommand(new DeleteCommand<MedicalRecord>(), medicalRecord);
        }
        public async Task<DbStatus> Update(MedicalRecord medicalRecord)
        {
            return await ServiceHelper<MedicalRecord>.ExecuteCRUDCommand(new UpdateCommand<MedicalRecord>(), medicalRecord);
        }

        public async Task<IList<MedicalRecord>> GetAll()
        {
            return await ServiceHelper<MedicalRecord>.ExecuteSelectCommand(new SelectAllCommand<MedicalRecord>());
        }

        public async Task<MedicalRecord> GetByPrimaryKey(MedicalRecord medicalRecord)
        {
            var list = await ServiceHelper<MedicalRecord>.ExecuteSelectCommand(new SelectWithPrimaryKeyCommand<MedicalRecord>(), medicalRecord);
            return list.Count != 0 ? list[0] : null;
        }
        public async Task<IList<MedicalRecord>> GetRange(int begin, int count)
        {

            return await ServiceHelper<MedicalRecord>.ExecuteSelectCommand(new SelectWithRangeCommand<MedicalRecord>(begin, count, "Name"));
        }

        public async Task<DbStatus> AddOrUpdate(MedicalRecord medicalRecord)
        {
            return await ServiceHelper<MedicalRecord>.ExecuteCRUDCommand(new InsertOrUpdateCommand<MedicalRecord>(), medicalRecord);

        }

        public async Task<MedicalRecord> GetByUniqueIdentifiers(string[] propertyNames, MedicalRecord entity, bool? deleted = null)
        {
            var list = await ServiceHelper<MedicalRecord>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<MedicalRecord>(propertyNames, deleted), entity);
            return list.Count != 0 ? list[0] : null;
        }

        public async Task<List<MedicalRecordsView>> GetAllViews()
        {
            return await ServiceHelper<MedicalRecordsView>.ExecuteSelectCommand(new SelectAllCommand<MedicalRecordsView>());

        }
        public async Task<List<MedicalRecordsView>> GetRangeViews(int begin, int count)
        {
            return await ServiceHelper<MedicalRecordsView>.ExecuteSelectCommand(new SelectWithRangeCommand<MedicalRecordsView>(begin, count, "Name"));
        }

        public async Task<int> GetTotalNumberOfItems()
        {
            return Convert.ToInt32(await ServiceHelper<MedicalRecord>.ExecuteScalarCommand(new CountCommand<MedicalRecord>()));
        }

    }
}
