using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.ExplicitInterface.Interfaces
{
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }
        string GetName();
    }
}
