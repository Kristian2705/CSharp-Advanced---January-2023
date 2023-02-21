using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
            => Count == 0;
        public Stack<string> AddRange(IEnumerable<string> strings)
        {
            foreach (string s in strings)
            {
                Push(s);
            }
            return this;
        }
    }
}
