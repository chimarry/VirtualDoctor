using AmbulanceDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceServices.Interfaces
{
    public interface ICrudServiceTemplate<T>
    {
        Task<DbStatus> Add(T entity);
        Task<DbStatus> Delete(T entity);
        Task<DbStatus> AddOrUpdate(T entity);
        Task<DbStatus> Update(T entity);

        Task<T> GetByPrimaryKey(T entity);
        Task<IList<T>> GetAll();

        Task<IList<T>> GetRange(int begin, int count);
        Task<T> GetByUniqueIdentifiers(string[] propertyNames, T entity, bool? deleted=null);

        Task<int> GetTotalNumberOfItems();
    }
}
