using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Raiding.Creators
{
    public class PaladinCreator : Creator
    {
        public override BaseHero FactoryMethod(string name)
            => new Paladin(name);
    }
}
