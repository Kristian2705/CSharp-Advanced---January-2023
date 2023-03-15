using Logger.Core.Appenders.Interfaces;
using Logger.Core.Enums;
using Logger.Core.Loggers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }
        public void Info(string dateTime, string message)
        {
            throw new NotImplementedException();
        }

        public void Warning(string dateTime, string message)
        {
            throw new NotImplementedException();
        }
        public void Error(string dateTime, string message)
        {
            throw new NotImplementedException();
        }
        public void Critical(string dateTime, string message)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string dateTime, string message)
        {
            throw new NotImplementedException();
        }

        private void AppendAll(string dateTime, string message, ReportLevel reportLevel)
        {

        }
    }
}
