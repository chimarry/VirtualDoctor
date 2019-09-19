using AmbulanceDatabase.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmbulanceServices.Interfaces
{
    public interface ILocalAccountService : ICrudServiceTemplate<LocalAccount>
    {
        Task<List<LocalAccount>> GetAllWithRoleNames();
    }
}
