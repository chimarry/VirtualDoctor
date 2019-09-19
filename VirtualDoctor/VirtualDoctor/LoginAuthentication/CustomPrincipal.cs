using System;
using System.Linq;
using System.Security.Principal;

namespace VirtualDoctor.LoginAuthentication
{
    public class CustomPrincipal : IPrincipal
    {

        private CustomIdentity _identity;

        public CustomIdentity Identity
        {
            get { return _identity ?? new AnonymousIdentity(); }
            set { _identity = value; }
        }

        IIdentity IPrincipal.Identity
        {
            get { return this.Identity; }
        }

        public bool IsInRole(string role)
        {
            return _identity.Roles.Contains(role);
        }
    }
}
