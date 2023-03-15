using _1.Logger.Models.Appenders.Interfaces;
using _1.Logger.Models.Loggers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Logger.Models.Loggers
{
    public class Logger : ILogger
    {
        private List<IAppender> appenders;
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders.ToList();
        }
        public void Log()
        {
            foreach(var appender in appenders)
            {
                //a collection of messages should be added
                //appender.WriteLine();
            }
        }
    }
}
