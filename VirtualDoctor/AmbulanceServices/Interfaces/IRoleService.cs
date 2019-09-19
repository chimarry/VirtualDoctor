using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceServices.Interfaces
{
    public interface IRoleService : ICrudServiceTemplate<Role>
    {
        Task<bool> ValidateEntry(Role role);
    }
}
