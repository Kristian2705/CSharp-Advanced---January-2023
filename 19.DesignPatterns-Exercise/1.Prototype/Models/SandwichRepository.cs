using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Prototype.Models
{
    public class SandwichRepository
    {
        private Dictionary<string, SandwichPrototype> sandwiches;
        
        public SandwichRepository()
        {
            sandwiches = new Dictionary<string, SandwichPrototype>();
        }

        public SandwichPrototype this[string name]
        {
            get => sandwiches[name];
            set
            {
                sandwiches.Add(name, value);
            }
        }
    }
}
