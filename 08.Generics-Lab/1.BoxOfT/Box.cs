using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> box;
        private int count;

        public Box()
        {
            box = new List<T>();
        }

        public int Count { get { return count; } }

        public void Add(T element)
        {
            count++;
            box.Insert(0, element);
        }

        public T Remove()
        {
            count--;
            T elementToRemove = box[0];
            box.RemoveAt(0);
            return elementToRemove;
        }
    }
}
