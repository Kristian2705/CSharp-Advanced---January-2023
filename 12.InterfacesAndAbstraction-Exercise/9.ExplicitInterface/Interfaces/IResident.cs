using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.ExplicitInterface.Interfaces
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; }
        string GetName();
    }
}
