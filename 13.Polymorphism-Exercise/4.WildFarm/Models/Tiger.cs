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

        }

        public override void Feed(Food food)
        {
            Console.WriteLine(ProduceSound());
            string foodType = food.GetType().Name;
            switch (foodType)
            {
                case "Meat":
                    FoodEaten += food.Quantity;
                    Weight += food.Quantity * TigerWeightModifier;
                    break;
                default:
                    Console.WriteLine($"{nameof(Tiger)} does not eat {foodType}!");
                    break;
            }
        }

        public override string ProduceSound()
            => "ROAR!!!";
    }
}
