using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceServices.Interfaces;
using AmbulanceServices.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmbulanceServices.Services
{
    public class TestResultsService : ITestResultsService
    {
        public async Task<DbStatus> Add(TestResults testResults)
        {
            return await ServiceHelper<TestResults>.ExecuteCRUDCommand(new InsertCommand<TestResults>(), testResults);
        }

        public async Task<DbStatus> Delete(TestResults testResults)
        {
            return await ServiceHelper<TestResults>.ExecuteCRUDCommand(new DeleteCommand<TestResults>(), testResults);
        }

        public async Task<DbStatus> Update(TestResults testResults)
        {
            return await ServiceHelper<TestResults>.ExecuteCRUDCommand(new UpdateCommand<TestResults>(), testResults);
        }

        public async Task<IList<TestResults>> GetAll()
        {
            return await ServiceHelper<TestResults>.ExecuteSelectCommand(new SelectAllCommand<TestResults>());
        }

        public async Task<TestResults> GetByPrimaryKey(TestResults testResults)
        {
            var list = await ServiceHelper<TestResults>.ExecuteSelectCommand(new SelectWithPrimaryKeyCommand<TestResults>(), testResults);
            return list.Count != 0 ? list[0] : null;
        }

        public Task<TestResults> GetByUniqueIdentifiers(params object[] identifiers)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TestResults>> GetRange(int begin, int count)
        {
            throw new NotImplementedException();
        }

        public async Task<DbStatus> AddOrUpdate(TestResults testResults)
        {
            return await ServiceHelper<TestResults>.ExecuteCRUDCommand(new InsertOrUpdateCommand<TestResults>(), testResults);
        }
    }
}
