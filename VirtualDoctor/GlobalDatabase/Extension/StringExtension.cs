using System;
using System.Collections.Generic;
using System.Text;

namespace Szz.Fd.Data.Graph.Extension
{
    public static class StringExtension
    {
        public static Dictionary<string, object> ToParamDictionary(this string value, string key)
        {
            return new Dictionary<string, object> { { key, value } };
        }
    }
}
