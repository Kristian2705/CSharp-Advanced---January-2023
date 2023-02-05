using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Tuple
{
    public class Tuple
    {
        private object item1;
        private object item2;

        public Tuple(object item1, object item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public object Item1 { get { return item1; } set { item1 = value; } }
        public object Item2 { get { return item2;} set { item2 = value; } }
    }
}
