using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.WildFarm.Models
{
    public class Cat : Feline
    {
        private const double CatWeightModifier = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            likedFood = new List<Type> { typeof(Vegetable), typeof(Meat) };
        }

        public override double WeightModifier => CatWeightModifier;

        public override string ProduceSound()
            => "Meow";
    }
}
