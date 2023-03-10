using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4.WildFarm.Core.Interfaces;

namespace _4.WildFarm.Core
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
            => Console.ReadLine();
    }
}
