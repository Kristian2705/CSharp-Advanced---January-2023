using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class Stack
    {
        private const int InitialSize = 4;
        private int[] items;

        public Stack()
        {
            items = new int[InitialSize];
            Count = 0;
        }
        public int Count { get; private set; }

        public void Push(int item)
        {
            if(Count == items.Length)
            {
                Resize();
            }
            for(int i = Count; i > 0; i--)
            {
                items[i] = items[i - 1];
            }
            items[0] = item;
            Count++;
        }

        public int Peek()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return items[0];
        }

        public int Pop()
        {
            if(Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var itemToPop = items[0];
            items[0] = 0;
            for(int i = 0; i <= Count; i++)
            {
                items[i] = items[i + 1];
            }
            Count--;
            if(Count <= items.Length / 4)
            {
                Shrink();
            }
            return itemToPop;
        }

        public void ForEach(Action<int> action)
        {
            for(int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];
            for(int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
    }
}
