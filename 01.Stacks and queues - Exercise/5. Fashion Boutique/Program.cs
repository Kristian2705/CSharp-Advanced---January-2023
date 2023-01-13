using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray().Reverse());
            int capacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int racks = 1;
            while (clothes.Count > 0)
            {
                if (capacity > sum + clothes.Peek())
                {
                    sum += clothes.Pop();
                }
                else if (capacity == sum + clothes.Peek())
                {
                    clothes.Pop();
                    if (clothes.Count != 0)
                    {
                        racks++;
                    }
                    sum = 0;
                }
                else
                {
                    sum = clothes.Pop();
                    racks++;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
