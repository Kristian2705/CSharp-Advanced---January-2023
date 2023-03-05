using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Raiding
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;
        public Warrior(string name) 
            : base(name)
        { }

        public override int Power => WarriorPower;

        public override string CastAbility()
            => $"{nameof(Warrior)} - {Name} hit for {Power} damage";
    }
}
