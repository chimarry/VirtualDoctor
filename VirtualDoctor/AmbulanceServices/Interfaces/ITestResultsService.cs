using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceServices.Interfaces
{
    public interface ITestResultsService
    {
        Task<DbStatus> Add(TestResults testResults);
        Task<DbStatus> AddOrUpdate(TestResults testResults);

        Task<DbStatus> Delete(TestResults testResults);

        Task<DbStatus> Update(TestResults testResults);

        Task<TestResults> GetByPrimaryKey(TestResults testResults);
        Task<IList<TestResults>> GetAll();
        Task<IList<TestResults>> GetRange(int begin, int count);

        Task<TestResults> GetByUniqueIdentifiers(params object[] identifiers);
    }
}
