using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Threeuple
{
    public class Threeuple
    {
        private object item1;
        private object item2;
        private object item3;

        public Threeuple(object item1, object item2, object item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public object Item1 { get { return item1; } set { item1 = value; } }
        public object Item2 { get { return item2; } set { item2 = value; } }
        public object Item3 { get { return item3; } set { item3 = value; } }
    }
}
