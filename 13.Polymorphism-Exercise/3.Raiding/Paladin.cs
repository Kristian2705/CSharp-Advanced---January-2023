using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Raiding
{
    public class Paladin : BaseHero
    {
        private const int PaladinPower = 100;
        public Paladin(string name) 
            : base(name)
        { }

        public override int Power => PaladinPower;

        public override string CastAbility()
            => $"{nameof(Paladin)} - {Name} healed for {Power}";
    }
}
