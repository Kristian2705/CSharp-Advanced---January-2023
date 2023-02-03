using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class List
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public List()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Add(int item)
        {
            if (items.Length == Count)
            {
                Resize();
            }
            items[Count] = item;
            Count++;
        }

        public int RemoveAt(int index)
        {
            ValidateIndex(index);
            int itemToRemove = items[index];
            items[index] = default;
            ShiftLeft(index);
            Count--;
            if(Count <= items.Length / 4)
            {
                Shrink();
            }
            return itemToRemove;
        }

        public void Insert(int index, int item)
        {
            if(index == Count)
            {
                Add(item);
                return;
            }
            ValidateIndex(index);
            if (items.Length == Count)
            {
                Resize();
            }
            ShiftRight(index);
            items[index] = item;
            Count++;
        }

        public bool Contains(int item)
        {
            for(int i = 0; i < Count; i++)
            {
                if(item == items[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int index1, int index2)
        {
            ValidateIndex(index1);
            ValidateIndex(index2);
            var swap = items[index1];
            items[index1] = items[index2];
            items[index2] = swap;
        }

        public void AddRange(int[] nums)
        {
            foreach(var num in nums)
            {
                Add(num);
            }
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for(int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void ShiftLeft(int index)
        {
            for(int i = index; i < Count - 1;i++)
            {
                items[i] = items[i + 1];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];
            for(int i = 0; i < copy.Length; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }

        private void ShiftRight(int index)
        {
            for(int i = Count; i >= index; i--)
            {
                items[i] = items[i - 1];
            }
        }
    }
}
