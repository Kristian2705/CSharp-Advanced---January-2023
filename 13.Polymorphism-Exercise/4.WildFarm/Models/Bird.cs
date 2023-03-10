using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.WildFarm.Models
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }

        public override string ToString()
            => base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
    }
}
