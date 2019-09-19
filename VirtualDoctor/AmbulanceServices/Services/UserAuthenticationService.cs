using AmbulanceDatabase.Entities;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceServices.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly ILocalAccountService localAccountService = ServicesAmbulanceFactory.GetInstance().CreateILocalAccountService();
        public async Task<LocalAccount> ValidateUser(string email, string password)
        {
            LocalAccount localAccount = new LocalAccount()
            {
                Email = email
            };
            
            localAccount = await localAccountService.GetByUniqueIdentifiers(new string[] { "Email" }, localAccount);
            if (localAccount == null)
            {
                return null;
            }
            //  bool passwordConfirmed = ValidatePassword(password, localAccount.PasswordHash);
            bool passwordConfirmed = password == localAccount.PasswordHash;
            return !passwordConfirmed ? null : localAccount;
        }

        public string HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hash);
        }
        private bool ValidatePassword(string password, string passwordHash)
        {
            return HashPassword(password) == passwordHash;
        }
    }
}
