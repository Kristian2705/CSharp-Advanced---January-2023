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
            likedFood = new List<Type> { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };
        }

        public override double WeightModifier => HenWeightModifier;

        public override string ProduceSound()
            => "Cluck";
    }
}
