using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Context
{
    public static class AttributeValueHelper
    {
        public static string IfStringDoQuotaiton(object entityAttribute)
        {
            if (entityAttribute == null)
            {
                return "null";
            }
            else if (entityAttribute.GetType() == typeof(string))
                return "\"" + entityAttribute + "\"";
            else if (entityAttribute.GetType() == typeof(DateTime))
            {
                return "Date(" + "\"" + ((DateTime)entityAttribute).ToString("yyyy-MM-dd H:mm:ss") + "\"" + ")";
            }
            else
                return entityAttribute.ToString();
        }
    }
}
