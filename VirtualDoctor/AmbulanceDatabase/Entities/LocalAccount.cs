using AmbulanceDatabase.Context;
using AmbulanceDatabase.Procedures;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Entities
{
    public class LocalAccount : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {
        public int IdLocalAccount
        {
            get; set;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public sbyte Deleted { get; set; }


        public void SetDeletedEntity(bool deleted)
        {
            Deleted = Convert.ToSByte(deleted);
        }
        public string GetAssociatedDbTableName()
        {
            return "Local_Account";
        }

        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdLocalAccount" };
        }

        private List<Role> roles;

        private string roleNames;
        public void SetRoleNames(string roles)
        {
            roleNames = roles;
        }
        public string GetRoleNames()
        {
            return roleNames;
        }
        public List<Role> GetRoles()
        {
            return roles;
        }
        public void SetRoles(List<Role> roles)
        {
            this.roles = roles;
        }
    }
}
