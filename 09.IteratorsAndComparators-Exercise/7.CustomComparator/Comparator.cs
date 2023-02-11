using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.CustomComparator
{
    public class Comparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if(x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }
            if(x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            return x.CompareTo(y);
            //if ((x & 1) == (y & 1))
            //{
            //    return x < y ? -1 : 1;
            //}
            //return ((x & 1) < (y & 1)) ? -1 : 1;
        }
    }
}
