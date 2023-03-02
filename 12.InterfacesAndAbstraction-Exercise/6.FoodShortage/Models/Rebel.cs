using _6.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        private const int RebelFoodIncrease = 5;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Group { get; set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += RebelFoodIncrease;
        }
    }
}
