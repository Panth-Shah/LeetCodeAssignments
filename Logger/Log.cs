using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public sealed class Log : ILog
    {
        private Log()
        {
        }
        private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());
        public static Log GetInstance
        {
            get
            {
                return instance.Value;
            }
        }

        public void LogException(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-----------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
        }
    }
}
