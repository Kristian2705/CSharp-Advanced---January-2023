using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.WildFarm.Models
{
    public class Tiger : Feline
    {
        private const double TigerWeightModifier = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            likedFood = new List<Type> { typeof(Meat) };
        }

        public override double WeightModifier => TigerWeightModifier;

        public override string ProduceSound()
            => "ROAR!!!";
    }
}
