using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALogger.Factories
{
    public class LoggerFactory
    {
        public static ILogger CreateLogger()
        {
            return new LogWriter();
        }
    }
}
