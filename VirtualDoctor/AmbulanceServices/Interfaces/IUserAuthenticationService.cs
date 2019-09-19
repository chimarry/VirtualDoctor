using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceServices.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<LocalAccount> ValidateUser(string email, string password);
        string HashPassword(string password);
    }
}
