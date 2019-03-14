using System;
using System.IO;

namespace SetACLs.Business
{
    public class LogWriter
    {
        private readonly string _logFilePath;

        public LogWriter(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void Write(string logMessage)
        {
            try
            {
                using (var w = File.AppendText(_logFilePath))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception)
            {
                // Ignored.
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception)
            {
                // Ignored.
            }
        }
    }
}
