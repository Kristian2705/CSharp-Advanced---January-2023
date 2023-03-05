using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Raiding.Creators
{
    public abstract class Creator
    {
        public abstract BaseHero FactoryMethod(string name);
    }
}
