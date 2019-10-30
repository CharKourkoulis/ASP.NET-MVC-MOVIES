
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public sealed class Log : ILog
    {

        private static Log _instance;

        private Log()
        {

        }

        public static Log GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Log();
                }
                return _instance;
            }
        }

        public void LogException(string message)
        {
            string filename = string.Format("{0}.log", "Exception");
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, filename);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---------------------------------");
            sb.Append(DateTime.Now.ToString());
            sb.AppendLine(message);

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }


    }
}
