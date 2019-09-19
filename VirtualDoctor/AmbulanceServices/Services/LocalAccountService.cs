using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using AmbulanceDatabase.Factories;
using AmbulanceDatabase.Procedures;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using AmbulanceServices.Shared;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceServices.Services
{
    public class LocalAccountService : ILocalAccountService
    {

        private readonly ILocalAccountRoleService localAccountRoleService = ServicesAmbulanceFactory.GetInstance().CreateILocalAccountRoleService();
        public async Task<DbStatus> Add(LocalAccount localAccount)
        {
            List<string> commandsToExecute = new List<string>();
            IConnector connector = ConnectorFactory.CreateConnector();
            MySqlConnection connection = connector.CreateConnection();
            await connector.OpenConnection(connection);
            LocalAccount currentAccount = await GetByUniqueIdentifiers(new string[] { "Email" }, localAccount);
            if (currentAccount != null && currentAccount.Deleted == 0)
            {
                return DbStatus.EXISTS;
            }
            else if (currentAccount != null && currentAccount.Deleted == 1)
            {
                DeleteOrUpdateRoles(currentAccount, localAccount, commandsToExecute, connection);

                commandsToExecute.Add(new InsertOrUpdateCommand<LocalAccount>().GetCommand(connection, localAccount.GetAssociatedDbTableName(), localAccount).CommandText);
            }
            else
            {
                commandsToExecute.Add(new InsertCommand<LocalAccount>().GetCommand(connection, localAccount.GetAssociatedDbTableName(), localAccount).CommandText);
                foreach (var role in localAccount.GetRoles())
                {
                    LocalAccountRole lr = new LocalAccountRole()
                    {
                        IdRole = role.IdRole
                    };
                    commandsToExecute.Add(new InsertIntoConnectionTableCommand<LocalAccountRole>("IdLocalAccount").GetCommand(connection, lr.GetAssociatedDbTableName(), lr).CommandText);

                }
            }
            DbTransactionProcedure transactionProcedure = new UpdateDbTransactionProcedure(commandsToExecute.ToArray());
            DbStatus status = await transactionProcedure.Execute();
            return status;

        }

        public async Task<DbStatus> Delete(LocalAccount localAccount)
        {
            List<string> commandsToExecute = new List<string>();
            IConnector connector = ConnectorFactory.CreateConnector();
            MySqlConnection connection = connector.CreateConnection();
            await connector.OpenConnection(connection);
            foreach (var role in localAccount.GetRoles())
            {
                LocalAccountRole lr = new LocalAccountRole()
                {
                    IdLocalAccount = localAccount.IdLocalAccount,
                    IdRole = role.IdRole
                };
                commandsToExecute.Add(new DeleteCommand<LocalAccountRole>().GetCommand(connection, lr.GetAssociatedDbTableName(), lr).CommandText);
            }
            commandsToExecute.Add(new DeleteCommand<LocalAccount>().GetCommand(connection, localAccount.GetAssociatedDbTableName(), localAccount).CommandText);
            DbTransactionProcedure transactionProcedure = new DeleteDbTransactionProcedure(commandsToExecute.ToArray());
            DbStatus status = await transactionProcedure.Execute();
            return status;
        }
        public async Task<DbStatus> Update(LocalAccount localAccount)
        {
            List<string> commandsToExecute = new List<string>();
            IConnector connector = ConnectorFactory.CreateConnector();
            MySqlConnection connection = connector.CreateConnection();
            await connector.OpenConnection(connection);
            LocalAccount currentAccount = await GetByPrimaryKey(localAccount);
            if (currentAccount == null)
            {
                return DbStatus.NOT_FOUND;
            }
            DeleteOrUpdateRoles(currentAccount, localAccount, commandsToExecute, connection);

            commandsToExecute.Add(new UpdateCommand<LocalAccount>().GetCommand(connection, localAccount.GetAssociatedDbTableName(), localAccount).CommandText);
            DbTransactionProcedure transactionProcedure = new UpdateDbTransactionProcedure(commandsToExecute.ToArray());
            DbStatus status = await transactionProcedure.Execute();
            return status;
        }

        public async Task<IList<LocalAccount>> GetAll()
        {
            var accounts = await ServiceHelper<LocalAccount>.ExecuteSelectCommand(new SelectAllCommand<LocalAccount>());
            accounts.ForEach(async x => x.SetRoles(await localAccountRoleService.GetAllRolesFor(x.IdLocalAccount) as List<Role>));
            return accounts;
        }

        public async Task<LocalAccount> GetByPrimaryKey(LocalAccount localAccount)
        {
            var list = await ServiceHelper<LocalAccount>.ExecuteSelectCommand(new SelectWithPrimaryKeyCommand<LocalAccount>(), localAccount);
            LocalAccount account = list.Count != 0 ? list[0] : null;
            if (account == null)
            {
                return null;
            }
            else
            {
                IList<Role> roles = await localAccountRoleService.GetAllRolesFor(localAccount.IdLocalAccount);
                account.SetRoles(roles as List<Role>);
                return account;

            }
        }
        public async Task<IList<LocalAccount>> GetRange(int begin, int count)
        {
            var accounts = await ServiceHelper<LocalAccount>.ExecuteSelectCommand(new SelectWithRangeCommand<LocalAccount>(begin, count, "Email"));
            accounts.ForEach(async x => x.SetRoles(await localAccountRoleService.GetAllRolesFor(x.IdLocalAccount) as List<Role>));
            return accounts;
        }

        public async Task<DbStatus> AddOrUpdate(LocalAccount localAccount)
        {
            List<string> commandsToExecute = new List<string>();
            IConnector connector = ConnectorFactory.CreateConnector();
            MySqlConnection connection = connector.CreateConnection();
            await connector.OpenConnection(connection);

            LocalAccount currentAccount = await GetByUniqueIdentifiers(new string[] { "Email" }, localAccount, false);
            DeleteOrUpdateRoles(currentAccount, localAccount, commandsToExecute, connection);

            commandsToExecute.Add(new InsertOrUpdateCommand<LocalAccount>().GetCommand(connection, localAccount.GetAssociatedDbTableName(), localAccount).CommandText);
            DbTransactionProcedure transactionProcedure = new UpdateDbTransactionProcedure(commandsToExecute.ToArray());
            DbStatus status = await transactionProcedure.Execute();
            return status;

        }

        public async Task<LocalAccount> GetByUniqueIdentifiers(string[] propertyNames, LocalAccount localAccount, bool? deleted = null)
        {
            var list = await ServiceHelper<LocalAccount>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<LocalAccount>(propertyNames, deleted), localAccount);
            LocalAccount dbAccount = list.Count != 0 ? list[0] : null;
            if (dbAccount == null)
            {
                return null;
            }
            else
            {
                IList<Role> roles = await localAccountRoleService.GetAllRolesFor(dbAccount.IdLocalAccount);
                dbAccount.SetRoles(roles as List<Role>);
                return dbAccount;
            }
        }

        public async Task<List<LocalAccount>> GetAllWithRoleNames()
        {
            DbParameter[] parameters = new InputDbParameter[] { };
            return await new GetActiveLocalAccountsDbStoredProcedure(parameters).ExecuteCommand() as List<LocalAccount>;
        }

        private void DeleteOrUpdateRoles(LocalAccount currentAccount, LocalAccount localAccount, List<string> commandsToExecute, MySqlConnection connection)
        {
            var rolesToDelete = currentAccount.GetRoles().Except(localAccount.GetRoles());
            var rolesToAdd = localAccount.GetRoles().Except(currentAccount.GetRoles());
            foreach (var role in rolesToDelete)
            {
                LocalAccountRole lr = new LocalAccountRole()
                {
                    IdLocalAccount = currentAccount.IdLocalAccount,
                    IdRole = role.IdRole
                };
                commandsToExecute.Add(new DeleteCommand<LocalAccountRole>().GetCommand(connection, lr.GetAssociatedDbTableName(), lr).CommandText);
            }
            foreach (var role in rolesToAdd)
            {
                LocalAccountRole lr = new LocalAccountRole()
                {
                    IdRole = role.IdRole,
                    IdLocalAccount = currentAccount.IdLocalAccount,
                    Deleted = 0
                };
                commandsToExecute.Add(new InsertOrUpdateCommand<LocalAccountRole>().GetCommand(connection, lr.GetAssociatedDbTableName(), lr).CommandText);

            }
        }

        public async Task<int> GetTotalNumberOfItems()
        {
            return Convert.ToInt32(await ServiceHelper<LocalAccount>.ExecuteScalarCommand(new CountCommand<LocalAccount>()));
        }

    }
}
