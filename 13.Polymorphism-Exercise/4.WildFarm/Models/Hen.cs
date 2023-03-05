using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.WildFarm.Models
{
    public class Hen : Bird
    {
        private const double HenWeightModifier = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        public override void Feed(Food food)
        {
            Console.WriteLine(ProduceSound());
            FoodEaten += food.Quantity;
            Weight += food.Quantity * HenWeightModifier;
        }

        public override string ProduceSound()
            => "Cluck";
    }
}
