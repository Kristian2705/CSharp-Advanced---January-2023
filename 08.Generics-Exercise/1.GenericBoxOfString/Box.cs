using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.GenericBoxOfString
{
    public class Box<T>
    {
        private T box;

        public Box(T item)
        {
            box = item;
        }

        public override string ToString()
        {
            return $"{box.GetType()}: {box}";
        }
    }
}
