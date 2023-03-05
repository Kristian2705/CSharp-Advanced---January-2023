using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.WildFarm.Models
{
    public class Owl : Bird
    {
        private const double OwlWeightModifier = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
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
                    Weight += food.Quantity * OwlWeightModifier;
                    break;
                default:
                    Console.WriteLine($"{nameof(Owl)} does not eat {foodType}!");
                    break;
            }
        }

        public override string ProduceSound()
            => "Hoot Hoot";
    }
}
