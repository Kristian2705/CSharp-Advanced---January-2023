using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public interface ICar
    {
        string Model { get; }
        string Color { get; }
        public string Start();
        public string Stop();
    }
}
