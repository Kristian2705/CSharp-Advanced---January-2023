using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const double MouseWeightModifier = 0.1;
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            likedFood = new List<Type> { typeof(Vegetable), typeof(Fruit) };
        }

        public override double WeightModifier => MouseWeightModifier;

        public override string ProduceSound()
            => "Squeak";

        public override string ToString()
            => $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
