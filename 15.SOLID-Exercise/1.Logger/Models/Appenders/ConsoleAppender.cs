using _1.Logger.Models.Appenders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
