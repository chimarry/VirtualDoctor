using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ALogger
{
    public class LogWriter : ILogger
    {
        private static readonly string LOG_FILE = "log.txt";
        private static readonly string SEPARATOR = "\\";
        private static readonly string NEW_LINE = Environment.NewLine;
        private static readonly string EXE_PATH = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


        public void Log(string logMessage)
        {
            try
            {
                using (StreamWriter w = File.AppendText(EXE_PATH + SEPARATOR + LOG_FILE))
                {
                    LogWrite(logMessage, w);
                }
            }
            catch (Exception)
            {
            }
        }


        public void LogWrite(string logMessage, TextWriter txtWriter)
        {
            try
            {
                var customPrincipal = Thread.CurrentPrincipal;

                txtWriter.Write(NEW_LINE + "Log Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("User:" + customPrincipal.Identity?.Name ?? string.Empty);
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception)
            {

            }
        }


    }
}