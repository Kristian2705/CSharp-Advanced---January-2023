using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;
        public Lake(params int[] values)
        {
            stones = values;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int lastIndex = 0;
            for(int i = 0; i < stones.Length; i += 2)
            {
                if(i + 2 >= stones.Length)
                {
                    lastIndex = i;
                }
                yield return stones[i];
            }
            if(lastIndex < stones.Length - 1)
            {
                for (int i = stones.Length - 1; i >= 0; i -= 2)
                {
                    yield return stones[i];
                }
            }
            else
            {
                for (int i = stones.Length - 2; i >= 0; i -= 2)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
