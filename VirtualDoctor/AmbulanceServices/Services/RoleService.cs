using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using AmbulanceServices.Interfaces;
using AmbulanceServices.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmbulanceServices.Services
{
    public class RoleService : IRoleService
    {
        public async Task<DbStatus> Add(Role role)
        {
            var dbRole = await GetByUniqueIdentifiers(new string[] { "RoleName" }, role, null);
            DbCommand<Role> commandToBeExecuted;
            if (dbRole == null)
            {
                commandToBeExecuted = new InsertCommand<Role>();
            }
            else if (dbRole.Deleted == 1)
            {
                commandToBeExecuted = new InsertOrUpdateCommand<Role>();
            }
            else
            {
                return DbStatus.EXISTS;
            }
            return await ServiceHelper<Role>.ExecuteCRUDCommand(commandToBeExecuted, role);


        }
        public async Task<DbStatus> AddOrUpdate(Role role)
        {
            return await ServiceHelper<Role>.ExecuteCRUDCommand(new InsertOrUpdateCommand<Role>(), role);
        }
        public async Task<DbStatus> Delete(Role role)
        {
            return await ServiceHelper<Role>.ExecuteCRUDCommand(new DeleteCommand<Role>(), role);
        }
        public async Task<DbStatus> Update(Role role)
        {
            return await ServiceHelper<Role>.ExecuteCRUDCommand(new UpdateCommand<Role>(), role);
        }

        public async Task<IList<Role>> GetAll()
        {
            return await ServiceHelper<Role>.ExecuteSelectCommand(new SelectAllCommand<Role>());
        }

        public async Task<Role> GetByPrimaryKey(Role role)
        {
            var list = await ServiceHelper<Role>.ExecuteSelectCommand(new SelectWithPrimaryKeyCommand<Role>(), role);
            return list.Count != 0 ? list[0] : null;
        }


        public async Task<IList<Role>> GetRange(int begin, int count)
        {
            return await ServiceHelper<Role>.ExecuteSelectCommand(new SelectWithRangeCommand<Role>(begin,count,"RoleName"));
        }

        public async Task<bool> ValidateEntry(Role role)
        {
            var dbRole = await GetByUniqueIdentifiers(new string[] { "RoleName" }, role, null);
            return dbRole == null ? true : false;
        }

        public async Task<Role> GetByUniqueIdentifiers(string[] propertyNames, Role role, bool? deleted = null)
        {
            var list = await ServiceHelper<Role>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<Role>(propertyNames, deleted), role);
            return list.Count != 0 ? list[0] : null;
        }

        public async Task<int> GetTotalNumberOfItems()
        {
            return Convert.ToInt32(await ServiceHelper<Role>.ExecuteScalarCommand(new CountCommand<Role>()));
        }

    }
}
