using _1.Logger.Models.Appenders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        public void WriteLine(string message)
        {
            using(StreamWriter sw = new StreamWriter("../../../logger.txt"))
            {
                sw.WriteLine(message);
            }
        }
    }
}
