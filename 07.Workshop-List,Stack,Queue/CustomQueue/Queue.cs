using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class Queue
    {
        private const int InitialSize = 4;
        private const int FirstElementIndex = 0;
        private int[] items;

        public Queue()
        {
            Count = 0;
            items = new int[InitialSize];
        }

        public int Count { get; private set; }

        public void Enqueue(int item)
        {
            if(Count == items.Length)
            {
                Resize();
            }
            items[Count] = item;
            Count++;
        }

        public int Dequeue()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            var itemToDequeue = items[FirstElementIndex];
            items[FirstElementIndex] = 0;
            for (int i = 0; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            Count--;
            if(Count == items.Length / 4)
            {
                Shrink();
            }
            return itemToDequeue;
        }

        public int Peek()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return items[FirstElementIndex];
        }

        public void Clear()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            items = new int[InitialSize];
            Count = 0;
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
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
    }
}
