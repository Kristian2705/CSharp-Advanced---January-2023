using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray());
            Console.WriteLine(orders.Max());
            while (orders.Count != 0)
            {
                if (n >= orders.Peek())
                {
                    n -= orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    break;
                }
            }
            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
