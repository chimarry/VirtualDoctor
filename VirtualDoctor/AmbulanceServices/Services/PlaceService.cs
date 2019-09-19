using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceServices.Interfaces;
using AmbulanceServices.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmbulanceServices.Services
{
    public class PlaceService : IPlaceService
    {
        public async Task<DbStatus> Add(Place place)
        {
            var dbPlace = await GetByUniqueIdentifiers(new string[] { "Name", "CountryName", "PostalCode" }, place);
            DbCommand<Place> commandToBeExecuted;
            if (dbPlace == null)
            {
                commandToBeExecuted = new InsertCommand<Place>();
            }
            else if (dbPlace.Deleted == 1)
            {
                commandToBeExecuted = new InsertOrUpdateCommand<Place>();
            }
            else
            {
                return DbStatus.EXISTS;
            }
            return await ServiceHelper<Place>.ExecuteCRUDCommand(commandToBeExecuted, place);


        }

        public async Task<DbStatus> Delete(Place place)
        {
            return await ServiceHelper<Place>.ExecuteCRUDCommand(new DeleteCommand<Place>(), place);
        }

        public async Task<DbStatus> Update(Place place)
        {
            return await ServiceHelper<Place>.ExecuteCRUDCommand(new UpdateCommand<Place>(), place);
        }

        public async Task<Place> GetByPrimaryKey(Place place)
        {
            var list = await ServiceHelper<Place>.ExecuteSelectCommand(new SelectWithPrimaryKeyCommand<Place>(), place);
            return list.Count != 0 ? list[0] : null;
        }
        public async Task<IList<Place>> GetAll()
        {
            return await ServiceHelper<Place>.ExecuteSelectCommand(new SelectAllCommand<Place>());
        }

        public async Task<IList<Place>> GetRange(int begin, int count)
        {
            return await ServiceHelper<Place>.ExecuteSelectCommand(new SelectWithRangeCommand<Place>(begin, count, "Name"));
        }

        public async Task<DbStatus> AddOrUpdate(Place place)
        {
            return await ServiceHelper<Place>.ExecuteCRUDCommand(new InsertOrUpdateCommand<Place>(), place);
        }

        public async Task<Place> GetByUniqueIdentifiers(string[] propertyNames, Place entity, bool? deleted = null)
        {
            var list = await ServiceHelper<Place>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<Place>(propertyNames, deleted), entity);
            return list.Count != 0 ? list[0] : null;
        }
        public async Task<int> GetTotalNumberOfItems()
        {
            return Convert.ToInt32(await ServiceHelper<Place>.ExecuteScalarCommand(new CountCommand<Place>()));
        }

    }
}
