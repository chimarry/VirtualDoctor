using AmbulanceDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceDatabase.Factories
{
    public class ConnectorFactory
    {
        public static IConnector CreateConnector()
        {
            return new Connector();
        }
    }
}
