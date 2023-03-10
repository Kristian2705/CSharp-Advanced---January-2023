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
            likedFood = new List<Type> { typeof(Meat) };
        }

        public override double WeightModifier => OwlWeightModifier;

        public override string ProduceSound()
            => "Hoot Hoot";
    }
}
