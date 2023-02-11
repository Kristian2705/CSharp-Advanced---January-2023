using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index;
        private List<T> list;
        public ListyIterator()
        {
            list = new List<T>();
        }
        public ListyIterator(params T[] values) : this()
        {
            list = values.ToList();
            index = 0;
        }
        public bool Move()
        {
            if (index < list.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (index < list.Count - 1)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(list[index]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
