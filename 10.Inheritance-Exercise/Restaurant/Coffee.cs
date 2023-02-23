using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double coffeeMilliliters = 50;
        private const decimal coffeePrice = 3.50m;
        public Coffee(string name, double caffeine) : base(name, 0, 0)
        {
            Caffeine = caffeine;
        }

        public override decimal Price { get => coffeePrice; }
        public override double Milliliters { get => coffeeMilliliters; }
        public double Caffeine { get; set; }
    }
}
