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

        }

        public override void Feed(Food food)
        {
            Console.WriteLine(ProduceSound());
            string foodType = food.GetType().Name;
            switch (foodType)
            {
                case "Vegetable":
                case "Meat":
                    FoodEaten += food.Quantity;
                    Weight += food.Quantity * CatWeightModifier;
                    break;
                default:
                    Console.WriteLine($"{nameof(Cat)} does not eat {foodType}!");
                    break;
            }
        }

        public override string ProduceSound()
            => "Meow";
    }
}
