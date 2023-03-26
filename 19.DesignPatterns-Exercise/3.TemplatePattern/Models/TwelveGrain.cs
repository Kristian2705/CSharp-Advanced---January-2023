using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TemplatePattern.Models
{
    public class TwelveGrain : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for the 12-Grain bread.");
        }

        public override void Bake()
        {
            Console.WriteLine($"Baking the 12-Grain bread. (25 minutes)");
        }
    }
}
