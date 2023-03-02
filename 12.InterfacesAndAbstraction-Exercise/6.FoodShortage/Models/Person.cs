using _6.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.FoodShortage.Models
{
    public class Person : IIdentifiable, IBirthable, IBuyer
    {
        private const int PersonFoodIncrease = 10;
        public Person(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public string Birthdate { get; set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += PersonFoodIncrease;
        }
    }
}
