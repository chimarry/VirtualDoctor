using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using AmbulanceDatabase.Procedures;
using AmbulanceServices.Interfaces;
using AmbulanceServices.Shared;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmbulanceServices.Services
{

    public class LocalAccountRoleService : ILocalAccountRoleService
    {
        public async Task<DbStatus> Add(LocalAccountRole entity)
        {
            var dbLocalAccountRole = await GetByUniqueIdentifiers(new string[] { "IdRole", "IdLocalAccount" }, entity, null);
            DbCommand<LocalAccountRole> commandToBeExecuted;
            if (dbLocalAccountRole == null)
            {
                commandToBeExecuted = new InsertCommand<LocalAccountRole>();
            }
            else if (dbLocalAccountRole.Deleted == 1)
            {
                commandToBeExecuted = new InsertOrUpdateCommand<LocalAccountRole>();
            }
            else
            {
                return DbStatus.EXISTS;
            }
            return await ServiceHelper<LocalAccountRole>.ExecuteCRUDCommand(commandToBeExecuted, entity);


        }

        public async Task<DbStatus> AddOrUpdate(LocalAccountRole entity)
        {
            return await ServiceHelper<LocalAccountRole>.ExecuteCRUDCommand(new InsertOrUpdateCommand<LocalAccountRole>(), entity);
        }




        public async Task<DbStatus> Delete(LocalAccountRole entity)
        {
            return await ServiceHelper<LocalAccountRole>.ExecuteCRUDCommand(new DeleteCommand<LocalAccountRole>(), entity);
        }

        public async Task<IList<LocalAccountRole>> GetAll()
        {
            return await ServiceHelper<LocalAccountRole>.ExecuteSelectCommand(new SelectAllCommand<LocalAccountRole>());
        }

        public Task<IList<LocalAccount>> GetAllLocalAccountsFor(int idRole)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Role>> GetAllRolesFor(int idLocalAccount)
        {
            DbParameter[] parameters = new InputDbParameter[] { new InputDbParameter("IdLocalAccountParam", MySqlDbType.Int32, idLocalAccount) };
            var list = await new GetRolesWithIdLocalAccountDbStoredProcedure(parameters).ExecuteCommand() as List<Role>;
            return list ?? new List<Role>();
        }

        public async Task<LocalAccountRole> GetByPrimaryKey(LocalAccountRole entity)
        {
            var list = await ServiceHelper<LocalAccountRole>.ExecuteSelectCommand(new SelectWithPrimaryKeyCommand<LocalAccountRole>(), entity);
            return list.Count != 0 ? list[0] : null;
        }

        public async Task<LocalAccountRole> GetByUniqueIdentifiers(string[] propertyNames, LocalAccountRole entity, bool? deleted = null)
        {
            var list = await ServiceHelper<LocalAccountRole>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<LocalAccountRole>(propertyNames, deleted), entity);
            return list.Count != 0 ? list[0] : null;
        }

        public Task<IList<LocalAccountRole>> GetRange(int begin, int count)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalNumberOfItems()
        {
            return Convert.ToInt32(await ServiceHelper<LocalAccountRole>.ExecuteScalarCommand(new CountCommand<LocalAccountRole>()));
        }

        public async Task<DbStatus> Update(LocalAccountRole entity)
        {
            return await ServiceHelper<LocalAccountRole>.ExecuteCRUDCommand(new UpdateCommand<LocalAccountRole>(), entity);
        }

    }
}
