using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _6.EqualityLogic
{
    public class Comparer : IEqualityComparer<Person>, IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if(x.Name.CompareTo(y.Name) < 0)
                return -1;
            if(x.Name.CompareTo(y.Name) > 0)
                return 1;
            if(x.Age.CompareTo(y.Age) < 0) 
                return -1;
            if(x.Age.CompareTo(y.Age) > 0) 
                return 1;
            return 0;
        }

        public bool Equals(Person x, Person y)
        {
            if (x.Name.CompareTo(y.Name) != 0 || x.Age.CompareTo(y.Age) != 0)
                return false;
            return true;
        }

        public int GetHashCode([DisallowNull] Person obj)
        {
            string code = obj.Name + "," + obj.Age;
            return code.GetHashCode();
        }
    }
}
