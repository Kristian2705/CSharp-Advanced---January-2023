using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            List<int> list = new List<int>();
            while (queue.Count > 0)
            {
                if (queue.Peek() % 2 != 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    list.Add(queue.Dequeue());
                }
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
