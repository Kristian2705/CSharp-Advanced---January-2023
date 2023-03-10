using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.WildFarm.Models
{
    public abstract class Animal
    {
        protected ICollection<Type> likedFood;
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public virtual double WeightModifier { get; protected set; }

        public virtual void Feed(Food food)
        {
            Console.WriteLine(ProduceSound());
            if (!likedFood.Contains(food.GetType()))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
            Weight += food.Quantity * WeightModifier;
        }
        public abstract string ProduceSound();

        public override string ToString()
            => $"{GetType().Name} [{Name}, ";
    }
}

