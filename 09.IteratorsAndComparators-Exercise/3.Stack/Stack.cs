using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace _3.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> values;
        public Stack()
        {
            values = new List<T>();
        }

        public int Count { get { return values.Count; } }

        public void Push(params T[] items)
        {
            T[] newValues = items;
            foreach (var item in newValues)
            {
                values.Add(item);
            }
        }

        public T Pop()
        {
            T lastValue = values[Count - 1];
            values.RemoveAt(Count - 1);
            return lastValue;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for(int i = Count - 1; i >= 0; i--)
            {
                yield return values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
