using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Logger.Models.Appenders.Interfaces
{
    public interface IAppender
    {
        void WriteLine(string message);
    }
}
