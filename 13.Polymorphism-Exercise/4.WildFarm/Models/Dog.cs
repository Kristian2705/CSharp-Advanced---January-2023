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

        }

        public override void Feed(Food food)
        {
            Console.WriteLine(ProduceSound());
            string foodType = food.GetType().Name;
            switch (foodType)
            {
                case "Meat":
                    FoodEaten += food.Quantity;
                    Weight += food.Quantity * DogWeightModifier;
                    break;
                default:
                    Console.WriteLine($"{nameof(Dog)} does not eat {foodType}!");
                    break;
            }
        }

        public override string ProduceSound()
            => "Woof!";

        public override string ToString()
            => $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
