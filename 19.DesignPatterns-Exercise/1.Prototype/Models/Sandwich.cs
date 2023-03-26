using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _1.Prototype.Models
{
    public class Sandwich : SandwichPrototype
    {
        private string meat;
        private string cheese;
        private string bread;
        private string veggies;

        public Sandwich(string meat, string cheese, string bread, string veggies)
        {
            this.meat = meat;
            this.cheese = cheese;
            this.bread = bread;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            string ingredients = GetIngredients();

            Console.WriteLine($"Cloning sandwich with ingredients: {ingredients}");

            return MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngredients()
            => $"{meat}, {cheese}, {bread}, {veggies}";
    }
}
