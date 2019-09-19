using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceServices.Interfaces
{
    public interface ILocalAccountRoleService : ICrudServiceTemplate<LocalAccountRole>
    {
        Task<IList<LocalAccount>> GetAllLocalAccountsFor(int idRole);
        Task<IList<Role>> GetAllRolesFor(int idLocalAccount);
    }
}
