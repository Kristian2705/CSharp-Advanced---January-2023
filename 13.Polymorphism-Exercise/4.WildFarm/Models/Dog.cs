using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.WildFarm.Models
{
    public class Dog : Mammal
    {
        private const double DogWeightModifier = 0.4;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            likedFood = new List<Type> { typeof(Meat) };
        }

        public override double WeightModifier => DogWeightModifier;

        public override string ProduceSound()
            => "Woof!";

        public override string ToString()
            => $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
