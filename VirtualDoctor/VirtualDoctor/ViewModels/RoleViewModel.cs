using System.Collections.Generic;
using System.Windows.Controls;

namespace VirtualDoctor.ViewModels
{
    public class RoleViewModel
    {

        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public override string ToString()
        {
            return RoleName;
        }
        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            var hashCode = 2065429282;
            hashCode = hashCode * -1521134295 + IdRole.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RoleName);
            return hashCode;
        }
    }
}
