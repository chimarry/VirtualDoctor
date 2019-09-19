using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDoctor.LoginAuthentication
{
    public class AnonymousIdentity : CustomIdentity
    {
        public AnonymousIdentity() : base(string.Empty, string.Empty, new string[] { }, string.Empty) { }

    }
}
