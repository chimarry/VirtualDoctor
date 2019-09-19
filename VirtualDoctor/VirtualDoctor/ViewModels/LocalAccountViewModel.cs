using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDoctor.ViewModels
{
    public class LocalAccountViewModel
    {
        public int IdLocalAccount { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
       
        public string Roles { get; set; }
        private List<Role> roles;
        public List<Role> GetRoles()
        {
            return roles;
        }
        public void SetRoles(List<Role> roles)
        {
            this.roles = roles;
        }

        public override string ToString()
        {
            return Email;
        }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return -506688385 + EqualityComparer<string>.Default.GetHashCode(Email);
        }
    }
}
