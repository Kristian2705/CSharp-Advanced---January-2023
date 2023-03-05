using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Raiding
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;
        public Druid(string name)
            : base(name)
        { }

        public override int Power => DruidPower;

        public override string CastAbility()
            => $"{nameof(Druid)} - {Name} healed for {Power}";
    }
}
