using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.GenericCountMethodString
{
    public class Box<T> where T : IComparable<T>
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

        public int CompareCounter(T item)
        {
            if (box.CompareTo(item) > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}
