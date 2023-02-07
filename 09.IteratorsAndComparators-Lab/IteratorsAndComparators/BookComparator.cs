using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if(x.Title.CompareTo(y.Title) < 0)
                return -1;
            if(x.Title.CompareTo(y.Title) > 0)
                return 1;
            if(y.Year.CompareTo(x.Year) < 0)
                return -1;
            if(y.Year.CompareTo(x.Year) > 0)
                return 1;
            return 0;
        }
    }
}
