using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Raiding
{
    public class Rogue : BaseHero
    {
        private const int RoguePower = 80;
        public Rogue(string name) 
            : base(name)
        { }

        public override int Power => RoguePower;

        public override string CastAbility()
            => $"{nameof(Rogue)} - {Name} hit for {Power} damage";
    }
}
