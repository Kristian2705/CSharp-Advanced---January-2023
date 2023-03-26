using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TemplatePattern.Models
{
    public class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for the WholeWheat bread.");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking the WholeWheat bread. (15 minutes)");
        }
    }
}
