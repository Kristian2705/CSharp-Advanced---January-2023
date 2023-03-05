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

        }

        public override void Feed(Food food)
        {
            Console.WriteLine(ProduceSound());
            string foodType = food.GetType().Name;
            switch(foodType)
            {
                case "Vegetabe":
                case "Fruit":
                    FoodEaten += food.Quantity;
                    Weight += food.Quantity * MouseWeightModifier;
                    break;
                default:
                    Console.WriteLine($"{nameof(Mouse)} does not eat {foodType}!");
                    break;
            }
        }

        public override string ProduceSound()
            => "Squeak";

        public override string ToString()
            => $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
