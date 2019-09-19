using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceServices.Interfaces;
using AmbulanceServices.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmbulanceServices.Services
{
    public class MedicalTitleService : IMedicalTitleService
    {
        public async Task<DbStatus> Add(MedicalTitle medicalTitle)
        {
            var dbMedicalTitle = await GetByUniqueIdentifiers(new string[] { "Name" }, medicalTitle);
            DbCommand<MedicalTitle> commandToBeExecuted;
            if (dbMedicalTitle == null)
            {
                commandToBeExecuted = new InsertCommand<MedicalTitle>();
            }
            else if (dbMedicalTitle.Deleted == 1)
            {
                commandToBeExecuted = new InsertOrUpdateCommand<MedicalTitle>();
            }
            else
            {
                return DbStatus.EXISTS;
            }
            return await ServiceHelper<MedicalTitle>.ExecuteCRUDCommand(commandToBeExecuted, medicalTitle);
        }

        public async Task<DbStatus> Delete(MedicalTitle medicalTitle)
        {
            return await ServiceHelper<MedicalTitle>.ExecuteCRUDCommand(new DeleteCommand<MedicalTitle>(), medicalTitle);
        }


        public async Task<DbStatus> Update(MedicalTitle medicalTitle)
        {
            return await ServiceHelper<MedicalTitle>.ExecuteCRUDCommand(new UpdateCommand<MedicalTitle>(), medicalTitle);
        }
        public async Task<IList<MedicalTitle>> GetAll()
        {
            return await ServiceHelper<MedicalTitle>.ExecuteSelectCommand(new SelectAllCommand<MedicalTitle>());
        }

        public async Task<MedicalTitle> GetByPrimaryKey(MedicalTitle medicalTitle)
        {
            var list = await ServiceHelper<MedicalTitle>.ExecuteSelectCommand(new SelectWithPrimaryKeyCommand<MedicalTitle>(), medicalTitle);
            return list.Count != 0 ? list[0] : null;
        }

        public async Task<DbStatus> AddOrUpdate(MedicalTitle medicalTitle)
        {
            return await ServiceHelper<MedicalTitle>.ExecuteCRUDCommand(new InsertOrUpdateCommand<MedicalTitle>(), medicalTitle);

        }

        public async Task<IList<MedicalTitle>> GetRange(int begin, int count)
        {
            return await ServiceHelper<MedicalTitle>.ExecuteSelectCommand(new SelectWithRangeCommand<MedicalTitle>(begin, count, "Name"));
        }

        public async Task<MedicalTitle> GetByUniqueIdentifiers(string[] propertyNames, MedicalTitle entity, bool? deleted = null)
        {
            var list = await ServiceHelper<MedicalTitle>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<MedicalTitle>(propertyNames, deleted), entity);
            return list.Count != 0 ? list[0] : null;
        }

        public async Task<int> GetTotalNumberOfItems()
        {
            return Convert.ToInt32(await ServiceHelper<MedicalTitle>.ExecuteScalarCommand(new CountCommand<MedicalTitle>()));
        }

    }
}
